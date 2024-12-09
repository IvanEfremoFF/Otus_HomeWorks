using System.Runtime.Intrinsics.X86;

namespace Exceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 0, b = 0, c = 0;
            double x1, x2;
            Console.CursorVisible = false;

            while (true)
            {
                if (InputABC(ref a, ref b, ref c) == ConsoleKey.Escape)
                    break;

                if (InputABC(ref a, ref b, ref c) == ConsoleKey.Enter)
                    CalculateEquation(a, b, c);
            }
        }

        private static void CalculateEquation(int a, int b, int c)
        {
            throw new NotImplementedException();
        }

        private static ConsoleKey InputABC(ref int a, ref int b, ref int c)
        {
            string _a = String.Empty, _b = String.Empty,  _c = String.Empty;
            byte menuItem = 1;


            while (true)
            { 
                Console.Clear();
                Console.WriteLine("*************************************");
                Console.WriteLine(" Finding roots of quadratic equation");
                Console.WriteLine("-------------------------------------");
                Console.WriteLine(" Up/Down to go through the menu. \n ENTER to confirm input. \n ESC to quit the program.");
                Console.WriteLine("*************************************");
                Console.Write("\n Input values: ");
                Console.WriteLine($"{(_a.Length > 0 ? _a : "a")} * x^2 + {(_b.Length > 0 ? _b : "b")} * x + {(_c.Length > 0 ? _c : "c")} = 0\n");

                switch (menuItem) 
                {
                    case 1:
                        Console.WriteLine($"-> a: {_a}\n   b: {_b}\n   c: {_c}");
                        break;

                    case 2:
                        Console.WriteLine($"   a: {_a}\n-> b: {_b}\n   c: {_c}");
                        break;

                    case 3:
                        Console.WriteLine($"   a: {_a}\n   b: {_b}\n-> c: {_c}");
                        break;

                    default:
                        menuItem = 1;
                        break;
                }

                var pressedKey = Console.ReadKey();
                switch (pressedKey.Key) 
                {
                    case ConsoleKey.DownArrow:
                        if (menuItem == 3)
                            menuItem = 1;
                        else
                            menuItem++;
                        break;

                    case ConsoleKey.UpArrow:
                        if (menuItem == 1)
                            menuItem = 3;
                        else
                            menuItem--;
                        break;

                    case ConsoleKey n when (n == ConsoleKey.OemMinus || n == ConsoleKey.Subtract || n <= ConsoleKey.NumPad9 && n >= ConsoleKey.NumPad0) || (n <= ConsoleKey.D9 && n >= ConsoleKey.D0):
                        switch (menuItem)
                        {
                            case 1:
                                if ((pressedKey.Key == ConsoleKey.OemMinus || pressedKey.Key == ConsoleKey.Subtract) && _a.Length == 0)
                                    _a = "-";
                                else if (pressedKey.Key == ConsoleKey.OemMinus || pressedKey.Key == ConsoleKey.Subtract)
                                    break;
                                else _a += pressedKey.KeyChar;
                                break;

                            case 2:
                                if ((pressedKey.Key == ConsoleKey.OemMinus || pressedKey.Key == ConsoleKey.Subtract) && _b.Length == 0)
                                    _b = "-";
                                else if (pressedKey.Key == ConsoleKey.OemMinus || pressedKey.Key == ConsoleKey.Subtract)
                                    break;
                                else
                                    _b += pressedKey.KeyChar;
                                break;

                            case 3:
                                if ((pressedKey.Key == ConsoleKey.OemMinus || pressedKey.Key == ConsoleKey.Subtract) && _c.Length == 0)
                                    _c = "-";
                                else if (pressedKey.Key == ConsoleKey.OemMinus || pressedKey.Key == ConsoleKey.Subtract)
                                    break;
                                else
                                    _c += pressedKey.KeyChar;
                                break;
                        }
                        break;


                    case ConsoleKey.Backspace:
                        switch (menuItem)
                        {
                            case 1:
                                _a = _a.Length > 0 ? _a.Substring(0, _a.Length - 1) : _a;
                                break;

                            case 2:
                                _b = _b.Length > 0 ? _b.Substring(0, _b.Length - 1) : _b;
                                break;

                            case 3:
                                _c = _c.Length > 0 ? _c.Substring(0, _c.Length - 1) : _c;
                                break;
                        }
                        break;


                    case ConsoleKey n when n == ConsoleKey.Escape || n == ConsoleKey.Enter:
                        return pressedKey.Key;

                    default:
                        break;
                }
            }
        }

    }
}
