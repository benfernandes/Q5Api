using System.ComponentModel.DataAnnotations;

namespace Q5Api.Dtos
{
    public class QueueUpdateDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}