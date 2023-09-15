namespace SumsAlrorithm
{
    public class Program
    {
        static void Main(string[] args)
        {
            SortedDictionary<int, int> availableCoins = new SortedDictionary<int, int>();
            Console.Write("How many types of coins do you have? ");
            int coinsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < coinsCount; i++)
            {
                Console.Write("Enter value of a coin: ");
                int value = int.Parse(Console.ReadLine());
                Console.Write($"Enter the count of the coin with value {value}: ");
                int count = int.Parse(Console.ReadLine());
                availableCoins.Add(value, count);
            }

            Console.WriteLine();
            Console.Write("Enter the total sum: ");
            int sum = int.Parse(Console.ReadLine());

            Dictionary<int, int> result = new Dictionary<int, int>();

            int remainingSum = sum;
            int sumOfCoins = 0;
            CheckForEnoughCoins(availableCoins, sumOfCoins, sum);

            foreach (var value in availableCoins.Keys.Reverse())
            {
                int coinCount = remainingSum / value;
                int availableCount = availableCoins[value];
                sumOfCoins = sumOfCoins + value * availableCount;

                
                if (coinCount <= availableCount)
                {
                    result.Add(value, coinCount);
                    remainingSum = remainingSum - coinCount * value;
                    int newAvailableCount = availableCount - coinCount;
                    availableCoins[value] = newAvailableCount;
                }
                else
                {
                    result.Add(value, availableCount);
                    remainingSum = remainingSum - availableCount * value;
                }

                if (remainingSum == 0)
                {
                    PrintCoins(result);
                    break;
                }

            }
        }
        public static void PrintCoins(Dictionary<int, int> result)
        {
            foreach (var pair in result)
            {
                Console.WriteLine("{0} -> {1}", pair.Key, pair.Value);
            }

        }
        public static void CheckForEnoughCoins(SortedDictionary<int, int> availableCoins, int sumOfCoins, int sum)
        {
            foreach (var value in availableCoins.Keys.Reverse())
            {
                int coinCount = sum / value;
                int availableCount = availableCoins[value];
                sumOfCoins = sumOfCoins + value * availableCount;
            }
            if(sumOfCoins < sum)
            {
                Console.WriteLine("You do not have enough coins!");
            }
        }
    }
}



