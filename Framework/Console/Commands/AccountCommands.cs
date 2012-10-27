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
 
using Framework.Database;
using Framework.Logging;

namespace Framework.Console.Commands
{
    public class AccountCommands : CommandParser
    {
        public static void CreateAccount(string[] args)
        {
            string name = Read<string>(args, 0).ToUpper();
            string password = Read<string>(args, 1);

            if (name == null || password == null)
                return;

            //byte[] hash = new SHA1CryptoServiceProvider().ComputeHash(Encoding.ASCII.GetBytes(password));
            //string hashString = BitConverter.ToString(hash).Replace("-", "");

            SQLResult result = DB.Realms.Select("SELECT * FROM accounts WHERE name = '{0}'", name);
            if (result.Count == 0)
            {
                if (DB.Realms.Execute("INSERT INTO accounts (name, password, language) VALUES ('{0}', '{1}', '')", name, password.ToUpper()))
                    Log.Message(LogType.NORMAL, "Account {0} successfully created", name);
            }
            else
                Log.Message(LogType.ERROR, "Account {0} already in database", name);
        }
    }
}
