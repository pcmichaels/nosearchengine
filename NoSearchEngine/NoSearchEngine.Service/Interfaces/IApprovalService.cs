using NoSearchEngine.DataAccess;
using NoSearchEngine.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoSearchEngine.Service.Interfaces
{
    public interface IApprovalService
    {
        IEnumerable<Resource> GetApprovalSiteList();
    }
}
