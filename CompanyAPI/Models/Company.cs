using System.ComponentModel.DataAnnotations;

namespace CompanyAPI.Models
{
    public class Company
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(250)]
        public string Name { get; set; }
    }
}
