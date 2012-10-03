using System;
using DefaultConsole = System.Console;

namespace Framework.Logging
{
    public class Log
    {
        static public void Message()
        {
            SetLogger(LogType.DEFAULT, "");
        }

        static public void Message(LogType type, string text, params object[] args)
        {
            SetLogger(type, text, args);
        }

        static void SetLogger(LogType type, string text, params object[] args)
        {
            switch (type)
            {
                case LogType.NORMAL:
                    DefaultConsole.ForegroundColor = ConsoleColor.Green;
                    text = text.Insert(0, "System: ");
                    break;
                case LogType.ERROR:
                    DefaultConsole.ForegroundColor = ConsoleColor.Red;
                    text = text.Insert(0, "Error: ");
                    break;
                case LogType.DUMP:
                    DefaultConsole.ForegroundColor = ConsoleColor.Yellow;
                    break;
                case LogType.INIT:
                    DefaultConsole.ForegroundColor = ConsoleColor.Cyan;
                    break;
                case LogType.MISC:
                    DefaultConsole.ForegroundColor = ConsoleColor.DarkBlue;
                    break;
                case LogType.CMD:
                    DefaultConsole.ForegroundColor = ConsoleColor.Green;
                    break;
                case LogType.DEBUG:
                    DefaultConsole.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                default:
                    DefaultConsole.ForegroundColor = ConsoleColor.White;
                    break;
            }

            if (type.Equals(LogType.INIT) | type.Equals(LogType.DEFAULT))
                DefaultConsole.WriteLine(text, args);
            else if (type.Equals(LogType.DUMP) || type.Equals(LogType.CMD))
                DefaultConsole.WriteLine(text, args);
            else
            {
                DefaultConsole.WriteLine("[" + DateTime.Now.ToLongTimeString() + "] " + text, args);
            }
        }
    }
}
