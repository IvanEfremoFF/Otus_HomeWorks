
namespace Interfaces
{
    internal class Quadcopter : IFlyingRobot, IChargeable
    {
        private List<string> _components = ["rotor1", "rotor2", "rotor3", "rotor4"];

        private int _batteryLevel { get; set; } = 0;

        public List<string> GetComponents() => _components;

        string IChargeable.GetInfo() => _batteryLevel.ToString();

        string IRobot.GetInfo() => "Quadcopter!";

        public void Charge()
        {
            Console.WriteLine("Charging...");
            Thread.Sleep(3000);
            Console.WriteLine("Charged!");
            _batteryLevel = 100;
        }
    }
}
