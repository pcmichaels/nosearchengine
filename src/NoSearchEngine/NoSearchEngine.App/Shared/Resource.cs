using System;
using System.Collections.Generic;
using System.Text;

namespace NoSearchEngine.App.Shared
{
    public class Resource
    {
        public string Url { get; set; }

        public ResourceType ResourceType { get; set; }

        public string Description { get; set; }
    }

    public enum ResourceType
    {
        TopLevelSite,
        SpecificUrl,
        FileDownload,
        Image,
        Video
    }
}
