using System.Collections.Generic;
using BurgerShack.Models;

namespace BurgerShack.Db
{
  static class FakeDB
  {
    public static List<Burger> Burgers = new List<Burger>(){
      new Burger("Cowboy", "Has shoestring onions", 12.50f),
      new Burger("Fresno Fig", "Has fig marmelade", 13.75f),
      new Burger("Bison", "Has strips of grilled peppers on it", 14.50f),
       
  };
  }
}