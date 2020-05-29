using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NoSearchEngine.App.Authorization;
using NoSearchEngine.DataAccess;
using NoSearchEngine.Service;
using NoSearchEngine.Service.Interfaces;
using System.Net.Http;
using WebSiteMeta.Scraper;
using WebSiteMeta.Scraper.HttpClientWrapper;

namespace NoSearchEngine.App
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationInsightsTelemetry();

            services.AddDbContext<NoSearchDbContext>(a =>
                a.UseSqlServer(Configuration.GetConnectionString("SqlConnectionString")));

            services.AddDefaultIdentity<ApplicationUserEntity>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<NoSearchDbContext>();

            services.AddAuthentication()
                .AddTwitter(o =>
                {
                    o.ConsumerKey = Configuration["Authentication:Twitter:ConsumerAPIKey"];
                    o.ConsumerSecret = Configuration["Authentication:Twitter:ConsumerSecret"];
                    o.RetrieveUserDetails = true;
                })
                .AddIdentityServerJwt();

            services.AddScoped<IAuthorizationHandler, ApproverAuthHandler>();

            services.AddAuthorization(o =>
            {
                o.AddPolicy("Approver", a => a.Requirements.Add(new ApproverAuthRequirement(100)));
            });

            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUserEntity, NoSearchDbContext>();

            services.AddControllersWithViews();
            services.AddRazorPages();

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });

            services.AddScoped<ISearchService, SearchService>();
            services.AddScoped<IResourceService, ResourceService>();
            services.AddScoped<IWebSiteService, WebSiteService>();
            services.AddScoped<IApprovalService, ApprovalService>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IResourceRepository, ResourceRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IFindMetaData, FindMetaData>(a =>
            {
                var factory = a.GetService<IHttpClientFactory>();
                var client = factory.CreateClient();
                var wrapper = new DefaultHttpClientWrapper(client);
                return new FindMetaData(wrapper);
            });            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseIdentityServer();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");

                endpoints.MapRazorPages();
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
