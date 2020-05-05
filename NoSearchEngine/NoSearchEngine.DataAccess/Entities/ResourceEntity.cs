using NoSearchEngine.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NoSearchEngine.DataAccess.Entities
{
    [Table("Resource")]
    public class ResourceEntity : Resource
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override string Id { get; set; }

        public static ResourceEntity FromModel(Resource resource) =>
            new ResourceEntity()
            {
                Id = resource.Id,
                Url = resource.Url,                
                Description = resource.Description
            };
    }
}
