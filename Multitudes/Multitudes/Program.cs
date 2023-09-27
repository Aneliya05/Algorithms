using System;
using System.Collections.Generic;

namespace Multitudes
{ 
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the elements of the Universe: ");
            List<int> universe = Console.ReadLine().Split(' ',StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            List<List<int>> bigSet = new List<List<int>>();
            Console.Write("Enter the count of the subsets: ");
            int subsetCount = int.Parse(Console.ReadLine());
            Console.WriteLine();
            for (int i = 1; i <= subsetCount; i++)
            {
                Console.Write($"Set number {i}: ");
                List<int> subset = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                bigSet.Add(subset);
            }
            bigSet = bigSet.OrderByDescending(x=>x.Count).ToList();

            List<List<int>> usedSets = new List<List<int>>();  
            
            do
            {
                List<int> longestSubset = bigSet.First().ToList();
                //var found = universe.FindAll(x => longestSubset.Contains(x));
                foreach (var element in longestSubset)
                {
                    
                    if (universe.Contains(element))
                    {
                        universe.Remove(element);
                        usedSets.Add(longestSubset);
                    }
                   
                    bigSet.RemoveAt(0);
                }
            }
            while (universe.Count != 0);

            Console.WriteLine();

            if (bigSet.Count != 0)
            {
                Console.WriteLine("Remaing sets: ");
                foreach (var list in bigSet)
                {
                    
                    foreach (var element in list)
                    {
                        Console.Write(element + " ");
                        
                    }
                    Console.WriteLine();
                } 
            }
            else
            {
                Console.WriteLine("There aren't any more elements left!");
            }
            Console.WriteLine();

            if (usedSets.Count != 0)
            {
                Console.WriteLine("Used sets:");
                foreach (var list in usedSets)
                {
                    foreach(var element in list)
                    {
                        Console.Write(element + " ");
                        
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("There weren't any sets used!");
            }


        }
    }
}