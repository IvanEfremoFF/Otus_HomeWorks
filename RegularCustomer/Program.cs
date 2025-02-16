using Microsoft.VisualBasic;
using System.Collections.ObjectModel;

namespace RegularCustomer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Otus Shop\n - A to add product\n - D to remove product\n - X to exit");
            var shop = new Shop();
            var customerJohn = new Customer("John");
            var customerHelen = new Customer("Helen");

            shop.Items.CollectionChanged += customerJohn.OnItemChanged;
            shop.Items.CollectionChanged += customerHelen.OnItemChanged;
            var randomID = new Random();

            while (true)
            {
                var pressedKey = Console.ReadKey();

                switch (pressedKey.Key)
                {                    
                    case ConsoleKey.A:
                        var currentDateTime = DateTime.Now;
                        var itemID = randomID.Next(1, 100);
                        var itemName = $"product of {currentDateTime}";

                        Console.WriteLine($"\nItem [{itemName}] with ID [{itemID}] added to the shop");
                        shop.Add(itemID, itemName);                   
                        
                        break;
                    case ConsoleKey.D:
                        Console.Write($"\nEnter product ID: ");
                        itemID = int.Parse(Console.ReadLine() ?? "0");
                        shop.Remove(itemID);

                        break;
                }
                
                if (pressedKey.Key == ConsoleKey.X)
                    break;
            }
            shop.Items.CollectionChanged -= customerJohn.OnItemChanged;
            shop.Items.CollectionChanged -= customerHelen.OnItemChanged;
        }
    }
}
