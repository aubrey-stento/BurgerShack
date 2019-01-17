using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BurgerShack.Models
{
    public class CustomerBurger
    {
        public int Id { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public int BurgerId { get; set; }
    }
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        // public IEnumerable<Burger> FavoriteBurgers { get; set; }

        // public IEnumerable<Side> FavoriteSides { get; set; }

    }
}