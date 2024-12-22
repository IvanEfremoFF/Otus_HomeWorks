
namespace Interfaces
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IRobot Q1 = new Quadcopter();
            Console.WriteLine($"Hello! \nI am {Q1.GetInfo()} {Q1.GetRobotType()}");
            Console.WriteLine($"I conatains of the next list of devices: {string.Join(" ", Q1.GetComponents())}");
            Console.WriteLine($"My battery level is {((IChargeable)Q1).GetInfo()}");
            ((IChargeable)Q1).Charge();
            Console.WriteLine($"My battery level is {((IChargeable)Q1).GetInfo()}");
        }
    }
}
