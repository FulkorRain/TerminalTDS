using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerminalTDS
{
    internal static class Logger
    {
        private static readonly string LogDirectory = "Logs";
        private static readonly string LogFile;
        private static readonly string LogPath;
        private static GameState? _state;

        static Logger()
        {
            Directory.CreateDirectory(LogDirectory);

            string timestamp = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
            LogFile = $"log_{timestamp}.txt";
            LogPath = Path.Combine(LogDirectory, LogFile);
            File.AppendAllText(LogPath, $"===== New Session Started {DateTime.Now} =====" + Environment.NewLine);
        }

        public static void LoggerSetState(GameState state)
        {
            _state = state;
        }
        public static void Log(string action, string from, string to, string message)
        {
            string time = DateTime.Now.ToString("HH:mm:ss");
            string line = $"[{time}] (Turn {_state?.TurnCount ?? -1}) {action}: {from} -> {to} | " + message;
            File.AppendAllText(LogPath, line + Environment.NewLine);
        }
    }
}
