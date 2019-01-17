using System.ComponentModel.DataAnnotations;

namespace BurgerShack.Models
{
    public class Side
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [MinLength(3)]
        public string Description { get; set; }
        // [Range(5, float.MaxValue)]
        public float Price { get; set; }

        // public Side(string name, string desc, float price)
        // {
        //     Name = name;
        //     Description = desc;
        //     Price = price;
        // }
    }
}