namespace CubeWorld.Console
{
    public interface ICWConsoleListener
    {
        void Log(CWConsole.LogLevel level, string message);
    }
}
