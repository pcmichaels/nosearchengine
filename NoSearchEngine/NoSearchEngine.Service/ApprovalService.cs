using NoSearchEngine.DataAccess;
using NoSearchEngine.Models;
using NoSearchEngine.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoSearchEngine.Service
{
    public class ApprovalService: IApprovalService
    {
        private readonly IResourceDataAccess _resourceDataAccess;

        public ApprovalService(IResourceDataAccess resourceDataAccess)
        {
            _resourceDataAccess = resourceDataAccess;
        }

        public IEnumerable<Resource> GetApprovalSiteList() =>        
            _resourceDataAccess.ByApproval(false);        
    }
}
