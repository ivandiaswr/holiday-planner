using System.ComponentModel.DataAnnotations;

namespace DataAccess.Dtos.Plan
{
    public class PlanUpdateDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        public string Place { get; set; } = string.Empty;
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [MaxLength(100)]
        public string AddicionalInformation { get; set; } = string.Empty;
    }
}
