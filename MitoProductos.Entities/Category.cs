using System.ComponentModel.DataAnnotations;

namespace MitoProductos.Entities
{
    public class Category : EntityBase
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(200)]
        public string Description { get; set; }
    }
}
