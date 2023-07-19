using System.ComponentModel.DataAnnotations;

namespace dotNet_api_service.Models.Dto
{
    public class VillaDTO
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }
    }
}
