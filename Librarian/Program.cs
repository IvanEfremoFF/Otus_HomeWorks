namespace Librarian
{
    internal class Program
    {
        static void Main(string[] args)
        {
                        
            var library = new Library();
            bool stopRecalculate = false;

            Thread recalculateReading = new Thread(() =>
            {
                while (!stopRecalculate)
                {
                    library.RecalculatePercentage();
                    Thread.Sleep(1000);
                }
            });
            recalculateReading.Start();


            while (true)
            {
                Console.Clear();
                Console.WriteLine("Please enter menu number to proceed: ");
                Console.WriteLine("1 - add book \n2 - show list of unread books \n3 - exit");
                var selectedMenu = Console.ReadLine();
                
                switch (selectedMenu)
                {
                    case "1":
                        Console.Write("Enter book name: ");
                        var bookName = Console.ReadLine();
                        library.AddBook(bookName ?? "");
                        break;
                    case "2":
                        Console.WriteLine($"List of unread books: \n{library.GetUnreadBooks()}");
                        break;
                }
                
                if (selectedMenu == "3")
                {
                    stopRecalculate = true;
                    break;
                }
                
                Console.Write("Press any key to continue...");
                Console.ReadKey();
            }

            recalculateReading.Join();
        }
    }
}
