using NoSearchEngine.Models;
using System.Threading.Tasks;
using WebSiteMeta.Scraper;
using NoSearchEngine.Service.Interfaces;

namespace NoSearchEngine.Service
{
    public class WebSiteService : IWebSiteService
    {
        private readonly IFindMetaData _findMetaData;

        public WebSiteService(IFindMetaData findMetaData)
        {
            _findMetaData = findMetaData;
        }

        public async Task<DataResult<SiteMetaData>> GetSiteMetaData(string url)
        {
            string cleanUrl = _findMetaData.CleanUrl(url);
            bool isValid = _findMetaData.ValidateUrl(cleanUrl);
            if (!isValid)
            {
                return DataResult<SiteMetaData>.Error(
                    new[] { "Url is invalid" });
            }

            var data = await _findMetaData.Run(cleanUrl);
            if (!data.IsSuccess)
            {                
                return DataResult<SiteMetaData>.Error(
                    new[] { "Unable to scrape site" });
            }

            return DataResult<SiteMetaData>.Success(new SiteMetaData()
            {
                Title = data.Metadata.Title,
                Description = data.Metadata.Description
            });
        }
    }
}
