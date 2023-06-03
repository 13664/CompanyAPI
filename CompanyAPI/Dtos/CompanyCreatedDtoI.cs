using System.ComponentModel.DataAnnotations;

namespace CompanyAPI.Dtos
{
    public class CompanyCreatedDtoI
    {
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
    }
}
