using System;
using System.ComponentModel.DataAnnotations;
namespace CRUDelicious.Models
{
    public class Dishes
    {
        [Key]
        public int ChefId { get; set; }
        public string Name { get; set; }
        public int Tastiness { get; set; }
        public int Calories { get; set; }
        public string Discription { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        
    }
}