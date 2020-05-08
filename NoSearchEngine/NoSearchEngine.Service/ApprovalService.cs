using NoSearchEngine.DataAccess;
using NoSearchEngine.Models;
using NoSearchEngine.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NoSearchEngine.Service
{
    public class ApprovalService: IApprovalService
    {
        private readonly IResourceRepository _resourceDataAccess;

        public ApprovalService(IResourceRepository resourceDataAccess)
        {
            _resourceDataAccess = resourceDataAccess;
        }

        public async Task<DataResult<Resource>> ApproveResource(string id, string subjectId)
        {
            var result = await _resourceDataAccess.ApproveById(id);
            return result;
        }

        public IEnumerable<Resource> GetApprovalSiteList() =>        
            _resourceDataAccess.ByApproval(false);        
    }
}
