using System;

namespace MyBackpackExercise
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Count of items in the backpack: ");
            int itemsCount = int.Parse(Console.ReadLine());
            Console.WriteLine();
            List<Item> items = new List<Item>();

            for (int i = 0; i < itemsCount; i++)
            {
                Console.Write("Enter the name of the item: ");
                string name = Console.ReadLine();
                Console.Write("Enter the weight of the item: ");
                double weight = double.Parse(Console.ReadLine());
                Console.Write("Enter the price of the item: ");
                decimal price = decimal.Parse(Console.ReadLine());
                Console.WriteLine();

                Item item = new Item(name, weight, price);
                items.Add(item);
            }
            Console.Write("Enter backpack volume: ");
            double backpackVolume = double.Parse(Console.ReadLine());
            Console.WriteLine();

            items = items.OrderByDescending(x => x.Price).ToList();

            List<Item> itemsInTheBackpack = new List<Item>();

            double remainingBackpackVolume = backpackVolume;
            foreach(var item in items)
            {
                if(item.Weight <= remainingBackpackVolume)
                {
                    itemsInTheBackpack.Add(item);
                    remainingBackpackVolume -= item.Weight;
                }
            }
            PrintItemsInBackpack(itemsInTheBackpack);
        }
        
        public static void PrintItemsInBackpack(List<Item> itemsInTheBackpack)
        {
            if(itemsInTheBackpack.Count > 0)
            {
                Console.WriteLine("------------------------------------------------------------------------------");
                Console.WriteLine("ITEMS IN BACKPACK:");
                Console.WriteLine();
                foreach (var item in itemsInTheBackpack)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            else
            
            {
                Console.WriteLine("Nothing can be put in the backpack!");
            }
        }
    }
}