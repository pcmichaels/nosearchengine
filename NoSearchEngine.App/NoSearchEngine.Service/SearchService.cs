﻿using NoSearchEngine.DataAccess;
using NoSearchEngine.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace NoSearchEngine.Service
{
    public class SearchService
    {
        private readonly IResourceDataAccess _resourceDataAccess;

        public SearchService(IResourceDataAccess resourceDataAccess)
        {
            _resourceDataAccess = resourceDataAccess;
        }

        public IEnumerable<Resource> Search(string searchText) => 
            _resourceDataAccess.SearchAll(searchText);        
    }
}
