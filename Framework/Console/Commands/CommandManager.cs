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

using Framework.Logging;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Framework.Console
{
    public class CommandManager
    {
        protected static Dictionary<string, HandleCommand> CommandHandlers = new Dictionary<string, HandleCommand>();
        public delegate void HandleCommand(string[] args);

        public static void InitCommands()
        {
            while (true)
            {
                Thread.Sleep(1);
                Log.Message(LogType.CMD, "Arctium >> ");

                string[] line = System.Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.None);
                string[] args = new string[line.Length - 1];
                Array.Copy(line, 1, args, 0, line.Length - 1);

                InvokeHandler(line[0].ToLower(), args);
            }
        }

        public static void DefineCommand(string command, HandleCommand handler)
        {
            CommandHandlers[command] = handler;
        }

        protected static bool InvokeHandler(string command, params string[] args)
        {
            if (CommandHandlers.ContainsKey(command))
            {
                CommandHandlers[command].Invoke(args);
                return true;
            }
            else
                return false;
        }
    }
}
