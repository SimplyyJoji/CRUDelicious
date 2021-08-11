using System;
using System.ComponentModel.DataAnnotations;
namespace CRUDelicious.Models
{
    public class Dishes
    {
        [Key]
        public int ChefId { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "Must be more then 1 character")]
        public string ChefName { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Must be more then 1 character")]
        
        public string Name { get; set; }
        [Required]
        public int Tastiness { get; set; }
        [Required]
        public int Calories { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Must be more then 3 character")]
        public string Discription { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        
    }
}