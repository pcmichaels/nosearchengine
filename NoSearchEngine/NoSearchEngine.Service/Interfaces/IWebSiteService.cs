using NoSearchEngine.Models;
using System.Threading.Tasks;

namespace NoSearchEngine.Service.Interfaces
{
    public interface IWebSiteService
    {
        Task<DataResult<SiteMetaData>> GetSiteMetaData(string url);
    }
}
