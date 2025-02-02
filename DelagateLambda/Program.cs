namespace DelagateLambda
{
    internal class Program
    {
        public static byte NumberOfValidations = 0;

        static void Main(string[] args)
        {
            var planetCatalogue = new PlanetCatalogue();
            (int NumberFromSun, int EquatorLength, string? message) result;
            

            while (true)
            {
                Console.Clear();
                Console.Write("Enter planet name: ");
                var input = Console.ReadLine();
                
                if (String.IsNullOrEmpty(input))
                    continue;

                Console.WriteLine("Searching info for planet \"{0}\" ...", input);

                result = planetCatalogue.GetPlanet(input, ValidationCriteria.LemoniaPlanet);
                if (!String.IsNullOrEmpty(result.message))
                    Console.WriteLine("\nSystem message: {0}", result.message);
                else
                {
                    result = planetCatalogue.GetPlanet(input, ValidationCriteria.RequestReached);
                    if (result.message == "No planet found.")
                        Console.WriteLine("\nSystem message: {0}", result.message);
                    else
                    {
                        Console.WriteLine("Planet \"{0}\" info: the order number from the Sun is {1}, length of its equator is {2}k km", input, result.NumberFromSun, result.EquatorLength);
                        Console.WriteLine("Systme message: {0}", result.message);
                    }
                }

                Console.Write("\nPress any key for continue (Esc to quit)...");
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                    return;

            }

        }
    }
}
