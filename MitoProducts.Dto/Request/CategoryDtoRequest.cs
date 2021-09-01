using System.ComponentModel.DataAnnotations;

namespace MitoProducts.Dto.Request
{
    public class CategoryDtoRequest
    {
        [Required(ErrorMessage ="El nombre es requerido")]
        [StringLength(50, ErrorMessage = "El nombre no puede exceder de 50")]
        public string Name { get; set; }
        [Required]
        [StringLength(200)]
        public string Description { get; set; }
    }
}
