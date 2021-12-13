using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeOne.Lib
{
    public class Menu
    {
        public int MenuId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public decimal Price { get; set; }
        public Menu()
        {
        }
        public Menu(string name, string description, string ingredients, decimal price)
        {
            Name = name;
            Description = description;
            Ingredients = ingredients;
            Price = price;
        }
    }
}
