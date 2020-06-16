using Microsoft.AspNetCore.Hosting;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NoSearchEngine.App.Helpers
{
    public static class Extensions
    {
        public static bool IsLocalDevelopment(this IWebHostEnvironment env)
        {
            return (env.IsEnvironment("LocalDevelopment"));
        }
    }
}
