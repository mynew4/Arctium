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
using System.IO;
using System.Text;

namespace Framework.Configuration
{
    public class Config
    {
        string[] ConfigContent;
        public string ConfigFile { get; set; }

        public Config(string config)
        {
            ConfigFile = config;

            if (!File.Exists(config))
            {
                Log.Message(LogType.ERROR, "{0} doesn't exist!", config);
                Environment.Exit(0);
            }
            else
                ConfigContent = File.ReadAllLines(config, Encoding.UTF8);
        }

        public T Read<T>(string name, T value)
        {
            string nameValue = null;
            T trueValue = (T)Convert.ChangeType(value, typeof(T));
            int lineCounter = 0;

            try
            {
                foreach (var option in ConfigContent)
                {
                    var configOption = option.Split(new char[] { '=' }, StringSplitOptions.None);
                    if (configOption[0].StartsWith(name, StringComparison.InvariantCulture))
                        if (configOption[1].Trim().Equals(""))
                            nameValue = value.ToString();
                        else
                            nameValue = configOption[1].Replace("\"", "").Trim();

                    if (typeof(T) == typeof(bool) && (nameValue != "0" && nameValue != "1"))
                    {
                        Log.Message(LogType.ERROR, "Error in {0} in line {1}", ConfigFile, lineCounter.ToString());
                        Log.Message(LogType.ERROR, "Use default value for boolean config option: {0}. Default: {1}", name, value);
                    }

                    lineCounter++;
                }
            }
            catch
            {
                Log.Message(LogType.ERROR, "Error in {0} in line {1}", ConfigFile, lineCounter.ToString());
            }

            return (T)Convert.ChangeType(nameValue, typeof(T));
        }
    }
}
