namespace CustomDictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var test1 = new OtusDictionary();
            var random = new Random();

            while (true)
            {
                Console.Write("\nEnter key (int): ");
                var key = Int32.Parse(Console.ReadLine() ?? "0");

                Console.Write("Enter value (string): ");
                var value = Console.ReadLine() ?? "";

                test1.Add(key, value);

                Console.Write("\nEnter key (int) to retrieve value: ");
                var  input = Int32.Parse(Console.ReadLine() ?? "0");
                Console.WriteLine($"Value: {test1.Get(input) ?? "key not found"}");

                Console.Write("\nEnter index (int) to retrieve value: ");
                input = Int32.Parse(Console.ReadLine() ?? "0");
                Console.WriteLine($"Value by index: {test1[input]}");

            }
        }
    }
}
