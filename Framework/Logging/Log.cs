/*
 * Copyright (C) 2012 Arctium <http://>
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */

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
