using NoSearchEngine.Models;
using System.Threading.Tasks;

namespace NoSearchEngine.Service.Interfaces
{
    public interface IResourceService
    {
        Task<DataResult<Resource>> AddResource(Resource resource, string Requestor);
        Task<DataResult<Resource>> DeleteResource(string id, string Requestor);
    }
}
