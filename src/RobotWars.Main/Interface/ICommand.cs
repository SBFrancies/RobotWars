namespace RobotWars.Main.Interface
{
    public interface ICommand
    {
        string CommandText { get; }

        void Run();
    }
}
