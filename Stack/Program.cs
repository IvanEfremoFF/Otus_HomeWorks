namespace Stack
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var s = new Stack("a", "b", "c");

            // size = 3, Top = 'c'
            Console.WriteLine($"size = {s.Size}, Top = '{s.Top}'");

            try {
                var deleted = s.Pop();
                // Извлек верхний элемент 'c' Size = 2
                Console.WriteLine($"Извлек верхний элемент '{deleted}' Size = {s.Size}");

            }
            catch (Exception ex) {
                Console.WriteLine(ex);
            }

            s.Add("d");

            // size = 3, Top = 'd'
            Console.WriteLine($"size = {s.Size}, Top = '{s.Top}'");

            try
            {
                s.Pop();
                s.Pop();
                s.Pop();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            // size = 0, Top = null
            Console.WriteLine($"size = {s.Size}, Top = {(s.Top == null ? "null" : s.Top)}");

            try
            {
                s.Pop();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            
            // 1. Implement Merge method extending Stack class
            var s1 = new Stack("a", "b", "c");
            s1.Merge(new Stack("1", "2", "3"));


            //2. Implement Concat static method in Stack class
            var s2 = Stack.Concat(new Stack("a", "b", "c"), new Stack("1", "2", "3"), new Stack("А", "Б", "В"));

            Console.WriteLine("End of program!");

        }
    }
}
