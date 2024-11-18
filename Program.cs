namespace MenuForTelegramBot 
{
    class Program 
    {
        static void Main(string[] args)
        {
            string userName = "";
            bool isNameEmpty = true;
            string programVersion = "1.0.0";
            string dateOfCreation = "18/11/2024";

            while (true)
            {
                Console.Clear();
                Console.Write($"Hi{(isNameEmpty ? "" : ", " + userName)}! ");
                Console.WriteLine($"Enter command: /start{(!isNameEmpty ? " /echo" : "")} /help /info /exit");
                string input = Console.ReadLine();

                switch (input.ToLower())
                {
                    case "/start":
                        Console.Write("Enter your name please: ");
                        userName = Console.ReadLine();
                        isNameEmpty = String.IsNullOrEmpty(userName);
                        Console.WriteLine($"{(isNameEmpty ? "No name was stored!" : "Your name stored.")}");
                        break;
                    case "/help":
                        Console.WriteLine(@"Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non  proident, sunt in culpa qui officia deserunt mollit anim id est laborum.");
                        break;
                    case "/info":
                        Console.WriteLine($"Program version: \t{programVersion}\nDate of creation: \t{dateOfCreation}");
                        break;
                    case string n when input.Split(' ')[0].ToLower() == "/echo":
                        if (!isNameEmpty)
                        {
                            string argument = input.Split(' ').Length > 1 ? input.Split(' ')[1] : "";
                            Console.WriteLine($"Entered argument of ECHO is: {(String.IsNullOrEmpty(argument) ? "no argument was entered" : argument)}");
                            break;
                        }
                        Console.WriteLine("Please provide us with your name for ECHO to be available.");
                        break;
                    case "/exit":
                        break;
                    default: 
                        Console.WriteLine("Unknown command entered! Please try again.");
                        break;
                };
                if (input.ToLower() == "/exit")
                    break;
                Console.Write("Press any key for continue...");
                Console.ReadKey();
            }
        }
    }
}
