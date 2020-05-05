using NoSearchEngine.DataAccess;
using NoSearchEngine.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NoSearchEngine.Service.Interfaces
{
    public interface IApprovalService
    {
        IEnumerable<Resource> GetApprovalSiteList();
        Task<DataResult<Resource>> ApproveResource(string id, string subjectId);
    }
}
