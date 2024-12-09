using System.ComponentModel.Design;
using System.Threading.Channels;

namespace MenuForTelegramBot 
{
    class Program
    {


        static void Main(string[] args)
        {
            List<string> taskList = new List<string>();
            int taskCount = 0;
            string userName = "";
            bool isNameEmpty = true;
            string programVersion = "1.2.0";
            string dateOfCreation = "18/11/2024";
            string info = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, \n" +
                                 "sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.\n" +
                                 "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris \n" +
                                 "nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in \n" +
                                 "reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. \n" +
                                 "Excepteur sint occaecat cupidatat non  proident, sunt in culpa qui officia \n" +
                                 "deserunt mollit anim id est laborum.";

            while (true)
            {
                Console.Clear();
                Console.Write($"Hi{(isNameEmpty ? "" : ", " + userName)}! ");
                Console.WriteLine($"Enter command: /start{(!isNameEmpty ? " /echo" : "")} /help /info /addtask /showtasks /removetask /exit");
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
                        Console.WriteLine(info);
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

                    case "/addtask":
                        Console.Write("Please enter task: ");
                        var newTask = Console.ReadLine();
                        if (AddTask(ref taskList, newTask, ref taskCount))
                        {
                            Console.WriteLine($"New task \"{newTask}\" added");
                        }
                        else
                        {
                            Console.WriteLine($"No task added: {(String.IsNullOrEmpty(newTask) ? "entered empty task." : "entered task exist.")}");
                        }
                        PrintTaskList(taskList, taskCount);
                        break;

                    case "/showtasks":
                        PrintTaskList(taskList, taskCount);
                        break;

                    case "/removetask":
                        PrintTaskList(taskList, taskCount);
                        if (taskCount > 0) 
                        {
                            Console.Write("Please enter task number to remove: ");
                            if (Int32.TryParse(Console.ReadLine(), out int taskIndex))
                            {
                                var removedTask = RemovedTask(ref taskList, taskIndex, ref taskCount);
                                Console.WriteLine($"Removed task: {(String.IsNullOrEmpty(removedTask) ? "no any task removed." : removedTask)}");
                                PrintTaskList(taskList, taskCount);
                            }
                            else
                            {
                                Console.WriteLine($"Entered incorrect value. Please try again!");
                            }
                        }
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


        static public void PrintTaskList(List<string> tasks, int taskCount)
        {
            if (taskCount > 0)
            {
                Console.WriteLine("\nCurrent task list:");
                foreach (var task in tasks)
                {
                    if (!String.IsNullOrEmpty(task))
                        Console.WriteLine($"{tasks.IndexOf(task.ToString())}. {task}");
                }
            }
            else
            {
                Console.WriteLine("\nTask list is empty yet. Add please at least one task.");
            }
        }

        static public bool AddTask(ref List<string> tasks, string task, ref int taskCount)
        {
            if (!String.IsNullOrEmpty(task) && !tasks.Contains(task))
            {
                tasks.Add(task);
                taskCount++;
                return true;
            }
            else
            {
                return false;
            }
        }

        static public string RemovedTask(ref List<string> tasks, int taskNumber, ref int taskCount)
        {
            if (taskNumber >= 0  && taskNumber < tasks.Count && !String.IsNullOrEmpty(tasks[taskNumber]))
            {
                var removedTask = tasks[taskNumber];
                taskCount--;
                tasks[taskNumber] = string.Empty;
                return removedTask;
            }
            else
            { 
                return String.Empty;
            }
        }



    }
}
