using NoSearchEngine.Models;
using System.Threading.Tasks;

namespace NoSearchEngine.Service.Interfaces
{
    public interface IAddResourceService
    {
        Task<bool> AddResource(Resource resource, string Requestor);
    }
}
