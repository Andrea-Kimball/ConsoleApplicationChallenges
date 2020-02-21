using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe
{
    public enum Ing { pickles=1, lettuce=2, onion=3, cheese=4, bacon=5, mayo=6, ketchup=7, mustard=8}
    public class Menu
    {
        static void Main(string[] args) { }

        public int ItemNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public Ing Ingredients { get; set; }


    
    public Menu() { }
        public Menu(int itemNumber, string name, string description, double price) 
        {
            ItemNumber = itemNumber;
            Name = name;
            Description = description;
            Price = price;
        }
    
}
}

