using System.Text;

namespace CubeWorld.Console
{
    public class CWConsole : ICWConsoleListener
    {
        private readonly StringBuilder log = new StringBuilder("");
        private string logCopy = null;

        public string TextLog
        {
            get 
            {
                if (logCopy == null)
                    logCopy = log.ToString();

                return logCopy;
            }
        }

        public ICWConsoleListener listener;
        public enum LogLevel
        {
            Info,
            Warning,
            Error
        }

        private CWConsole()
        {
        }

        private static CWConsole singleton;

        public static CWConsole Singleton
        {
            get { if (singleton == null) singleton = new CWConsole(); return singleton; }
        }

        public void Log(LogLevel level, string message)
        {
            log.AppendLine(level.ToString() + " : " + message);
            logCopy = null;

            if (listener != null)
                listener.Log(level, message);
        }

        public static void LogError(string message)
        {
            Singleton.Log(LogLevel.Error, message);
        }

        public static void LogWarning(string message)
        {
            Singleton.Log(LogLevel.Warning, message);
        }

        public static void LogInfo(string message)
        {
            Singleton.Log(LogLevel.Info, message);
        }
    }
}
