using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBackpackExercise
{
    public class Item
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public decimal Price { get; set; }

        public Item(string name, double weight, decimal price)
        {
            this.Name = name;
            this.Weight = weight;
            this.Price = price;
        }

        public override string ToString()
        {
            return $"{this.Name} | Weight: {this.Weight}kg | Price: {this.Price}lv. ";
        }
    }
}
