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
            List<List<int>> unusedSubsets = new List<List<int>>();
            List<int> removedFromUniverse = new List<int>();
            do
            {
                List<int> longestSubset = new List<int>();
                
                if (bigSet.Count != 0)
                {
                    longestSubset = bigSet.First().ToList();
                    foreach (var element in longestSubset)
                    {

                        if (universe.Contains(element))
                        {
                            //universe.Remove(element);
                            removedFromUniverse.Add(element);
                            usedSets.Add(longestSubset);
                            usedSets = usedSets.Distinct().ToList();
                        }
                        if (!removedFromUniverse.Contains(element))
                        {
                            Console.WriteLine();
                            Console.WriteLine($"Universe does not contain this element: {element}");
                            unusedSubsets.Add(longestSubset);
                        }

                    }
                    bigSet.RemoveAt(0);
                }
 
                else
                {
                    if(universe.Count == 1)
                    {
                        Console.WriteLine($"The only element in the Universe left is: {universe.Single()}");
                        break;
                    }
                    else
                    if(universe.Count > 1)
                    {
                        Console.Write($"The only elements in the Universe left are: ");
                        foreach (var element in universe)
                        {
                            Console.Write(element + " ");
                        }
                        break;
                    } 
                }
                foreach (var element in removedFromUniverse)
                {
                    universe.Remove(element);
                }
                //var found = universe.FindAll(x => longestSubset.Contains(x));
            }
            while (universe.Count != 0);
            
            //foreach(var element in removedFromUniverse)
            //{
            //    foreach(var list in unusedSubsets)
            //    {
            //        list.Remove(element);
            //    }
            //}
            Console.WriteLine();
            
            if (unusedSubsets.Count != 0)
            {
                unusedSubsets = unusedSubsets.Distinct().ToList();
                Console.WriteLine("Remaining sets or elements: ");
                foreach (var list in unusedSubsets)
                {
                    
                    foreach (var element in list)
                    {
                        if (!removedFromUniverse.Contains(element))
                        {
                            Console.Write(element + " ");
                        }
                        
                    }
                    Console.WriteLine();
                } 
            }
            else
            {
                Console.WriteLine("There aren't any unused elements left in the set of sets!");
            }
            Console.WriteLine();

            if (usedSets.Count != 0)
            {
                Console.WriteLine("Used sets or elements:");
                foreach (var list in usedSets)
                {
                    foreach(var element in list)
                    {
                        if (removedFromUniverse.Contains(element))
                        {
                            Console.Write(element + " ");
                        }
                        
                        
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