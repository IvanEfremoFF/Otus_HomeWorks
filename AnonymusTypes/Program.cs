using System.Net.WebSockets;

namespace AnonymusTypes
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var Planet1 = new
            {
                Name = "Venus",
                NumberFromSun = 2,
                EquatorLength = 38025
            };

            var Planet2 = new
            {
                Name = "Earth",
                NumberFromSun = 3,
                EquatorLength = 40075,
                PrevousePlanet = Planet1
            };

            var Planet3 = new
            {
                Name = "Mars",
                NumberFromSun = 4,
                EquatorLength = 38025,
                PrevousePlanet = Planet2
            };

            var Planet4 = new
            {
                Name = "Venus",
                NumberFromSun = 2,
                EquatorLength = 38025
            };

            Console.WriteLine("Planet {0}: \n\tnumber from the Sun - {1} \n\tlength of Equator - {2}", Planet1.Name, Planet1.NumberFromSun, Planet1.EquatorLength);
            Console.WriteLine("\tthe prevouse planet is {0}", null);
            Console.WriteLine("\tthe same like Venus - {0}", Planet1.Equals(Planet1));

            Console.WriteLine("Planet {0}: \n\tnumber from the Sun - {1} \n\tlength of Equator - {2}", Planet2.Name, Planet2.NumberFromSun, Planet2.EquatorLength);
            Console.WriteLine("\the prevouse planet is {0}", Planet2.PrevousePlanet.Name);
            Console.WriteLine("\tthe same like Venus - {0}", Planet2.Equals(Planet1));

            Console.WriteLine("Planet {0}: \n\tnumber from the Sun - {1} \n\tlength of Equator - {2}", Planet3.Name, Planet3.NumberFromSun, Planet3.EquatorLength);
            Console.WriteLine("\the prevouse planet is {0}", Planet3.PrevousePlanet.Name);
            Console.WriteLine("\tthe same like Venus - {0}", Planet3.Equals(Planet1));

            Console.WriteLine("Planet {0}: \n\tnumber from the Sun - {1} \n\tlength of Equator - {2}", Planet4.Name, Planet4.NumberFromSun, Planet4.EquatorLength);
            Console.WriteLine("\the prevouse planet is {0}", null);
            Console.WriteLine("\tthe same like Venus - {0}", Planet4.Equals(Planet1));
        }
    }
}
