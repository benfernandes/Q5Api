using System.ComponentModel.DataAnnotations;

namespace Q5Api.Models
{
    public class Queue
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
    }
}