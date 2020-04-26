namespace NoSearchEngine.Models
{
    public class Resource
    {
        public string Url { get; set; }
        public string Description { get; set; }
        public bool IsApproved { get; set; } = false;
    }
}
