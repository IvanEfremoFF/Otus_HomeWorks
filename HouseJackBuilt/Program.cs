using System.Collections.Immutable;

namespace JackHouse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var part1 = new Part1();
            var part2 = new Part2();
            var part3 = new Part3();
            var part4 = new Part4();
            var part5 = new Part5();
            var part6 = new Part6();
            var part7 = new Part7();
            var part8 = new Part8();
            var part9 = new Part9();

            ImmutableList<string> listOfLines;

            listOfLines = part1.AddPart(ImmutableList<string>.Empty);
            listOfLines = part2.AddPart(listOfLines);
            listOfLines = part3.AddPart(listOfLines);
            listOfLines = part4.AddPart(listOfLines);
            listOfLines = part5.AddPart(listOfLines);
            listOfLines = part6.AddPart(listOfLines);
            listOfLines = part7.AddPart(listOfLines);
            listOfLines = part8.AddPart(listOfLines);
            listOfLines = part9.AddPart(listOfLines);

            Console.WriteLine("*** Result of separated parts ***");
            Console.WriteLine("\tPart1\n" + string.Join("\n", part1.Poem.Select(x => x)));
            Console.WriteLine("\tPart2\n" + string.Join("\n", part2.Poem.Select(x => x)));
            Console.WriteLine("\tPart3\n" + string.Join("\n", part3.Poem.Select(x => x)));
            Console.WriteLine("\tPart4\n" + string.Join("\n", part4.Poem.Select(x => x)));
            Console.WriteLine("\tPart5\n" + string.Join("\n", part5.Poem.Select(x => x)));
            Console.WriteLine("\tPart6\n" + string.Join("\n", part6.Poem.Select(x => x)));
            Console.WriteLine("\tPart7\n" + string.Join("\n", part7.Poem.Select(x => x)));
            Console.WriteLine("\tPart8\n" + string.Join("\n", part8.Poem.Select(x => x)));
            Console.WriteLine("\tPart9\n" + string.Join("\n", part9.Poem.Select(x => x)));

            Console.WriteLine("\n\n\n*** Result of one line ***");
            Console.WriteLine(string.Join("\n\n", listOfLines.Select(x => x)));

        }
    }
}
