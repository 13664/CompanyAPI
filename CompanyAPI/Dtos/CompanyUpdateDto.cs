using System.ComponentModel.DataAnnotations;

namespace CompanyAPI.Dtos
{
    public class CompanyUpdateDto
    {
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
    }
}
