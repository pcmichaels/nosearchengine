using System;
using System.Text;

namespace NoSearchEngine.Common.Helpers
{
    public static class UrlHelper
    {
        public static string GetUrlBase(string url)
        {
            string returnVal = url
                .Replace("http://www.", "")
                .Replace("http://", "")
                .Replace("https://www.", "")
                .Replace("https://", "");
            
            if (returnVal.StartsWith("www."))
            {
                returnVal = returnVal.Remove(0, 4);
            }

            return returnVal;
        }
    }
}
