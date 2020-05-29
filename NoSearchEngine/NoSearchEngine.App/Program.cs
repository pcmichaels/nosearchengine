using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Azure.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureKeyVault;

namespace NoSearchEngine.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .ConfigureAppConfiguration((hostingContext, config) =>
                        {
                            var settings = config.Build();
                            var defaultAzureCredentialsOptions = new DefaultAzureCredentialOptions();                            

                            config.AddAzureAppConfiguration(options =>
                            {                                
                                options.Connect(settings["ConnectionStrings:AppConfig"])
                                    .ConfigureKeyVault(kv =>
                                    {
                                        kv.SetCredential(new DefaultAzureCredential(defaultAzureCredentialsOptions));
                                    });
                            });
                        })                                        
                        .UseStartup<Startup>();
                });
    }
}
