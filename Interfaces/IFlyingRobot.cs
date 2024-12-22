
namespace Interfaces
{
    interface IFlyingRobot : IRobot
    {
        string IRobot.GetRobotType() => "I am a flying robot.";

    }
}
