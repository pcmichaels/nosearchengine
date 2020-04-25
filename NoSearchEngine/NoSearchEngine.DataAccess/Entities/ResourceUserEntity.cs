using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NoSearchEngine.DataAccess.Entities
{
    [Table("ResourceUser")]
    public class ResourceUserEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public ResourceEntity Resource { get; set; }
        public ApplicationUserEntity User { get; set; }
    }
}
