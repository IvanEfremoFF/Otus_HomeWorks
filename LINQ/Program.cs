namespace LINQ
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("*** Take 7 elements ***");            
            Console.WriteLine("Input");
            var list1 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            list1.ForEach(x => Console.Write($"{x} "));
            Console.WriteLine("\nResult");
            list1.Take(7).ToList().ForEach(x => Console.Write($"{x} "));


            Console.WriteLine("\n\n*** Top 30% of elements ***");
            Console.WriteLine("Input");
            var list2 = new List<int> { 7, 32, 3, 0, 43, 86, 78, 14, 45 };
            list2.ForEach(x => Console.Write($"{x} "));
            Console.WriteLine("\nResult");
            list2.Top(30).ToList().ForEach(x => Console.Write($"{x} "));


            Console.WriteLine("\n\n*** Top 120% of elements ***");
            Console.WriteLine("Input");
            var list3 = new List<int> { 1, 3, 6, 9, 4, 8 };
            list3.ForEach(x => Console.Write($"{x} "));
            Console.WriteLine("\nResult");
            try
            {
                list3.Top(120).ToList().ForEach(x => Console.Write($"{x} "));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);                
            }

            Console.WriteLine("\n\n*** Top 30% of elements in list of persons ordered by Age***");
            Console.WriteLine("Input");
            var list4 = new List<Person>
                {
                    new Person { Name = "Peter", Age = 25 },
                    new Person { Name = "Anna", Age = 41 },
                    new Person { Name = "Sergey", Age = 34 },
                    new Person { Name = "Alice", Age = 25 },
                    new Person { Name = "Ivan", Age = 29 },
                    new Person { Name = "Helen", Age = 27 },
                    new Person { Name = "Boris", Age = 31 },
                    new Person { Name = "Nika", Age = 30 },
                };

            list4.ForEach(x => Console.WriteLine($"[{x.Name} - {x.Age}]"));
            Console.WriteLine("\nResult of top 30 ages ordering by age descending");
            list4.Top(30, list4 => list4.Age).ToList().ForEach(x => Console.WriteLine($"[{x.Name} - {x.Age}]"));
            Console.WriteLine("\nResult of top 30 names ordering by alphabet descending");
            list4.Top(30, list4 => list4.Name).ToList().ForEach(x => Console.WriteLine($"[{x.Name} - {x.Age}]"));
        }
    }
}
