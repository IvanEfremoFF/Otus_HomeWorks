
namespace Interfaces
{
    interface IRobot
    {
        string GetInfo();

        List<string> GetComponents();

        string GetRobotType() => "I am a simple robot.";

    }
}
