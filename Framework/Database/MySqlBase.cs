using System.Data;
using MySql.Data.MySqlClient;
using System.Text;
using Framework.Logging;
using System.Threading;
using System.Globalization;

namespace Framework.Database
{
    public class MySqlBase
    {
        MySqlConnection Connection;
        MySqlDataReader SqlData;

        public int RowCount { get; set; }

        public void Init(string host, string user, string password, string database, int port)
        {
            Connection = new MySqlConnection("Server=" + host + ";User Id=" + user + ";Port=" + port + ";" + 
                                             "Password=" + password + ";Database=" + database + ";Allow Zero Datetime=True");

            try
            {
                Connection.Open();
                Log.Message(LogType.NORMAL, "Successfully connected to {0}:{1}:{2}", host, port, database);
            }
            catch (MySqlException ex)
            {
                Log.Message(LogType.ERROR, "{0}", ex.Message);

                // Try auto reconnect on error (every 5 seconds)
                Log.Message(LogType.NORMAL, "Try reconnect in 5 seconds...");
                Thread.Sleep(5000);

                Init(host, user, password, database, port);
            }
        }

        public bool Execute(string sql, params object[] args)
        {
            StringBuilder sqlString = new StringBuilder();
            // Fix for floating point problems on some languages
            sqlString.AppendFormat(CultureInfo.GetCultureInfo("en-US").NumberFormat, sql, args);

            MySqlCommand sqlCommand = new MySqlCommand(sqlString.ToString(), Connection);

            try
            {
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException ex)
            {
                Log.Message(LogType.ERROR, "{0}", ex.Message);
                return false;
            }
        }

        public SQLResult Select(string sql, params object[] args)
        {
            SQLResult retData = new SQLResult();

            StringBuilder sqlString = new StringBuilder();
            // Fix for floating point problems on some languages
            sqlString.AppendFormat(CultureInfo.GetCultureInfo("en-US").NumberFormat, sql, args);

            MySqlCommand sqlCommand = new MySqlCommand(sqlString.ToString(), Connection);
            
            try
            {
                SqlData = sqlCommand.ExecuteReader(CommandBehavior.Default);
                retData.Load(SqlData);
                retData.Count = retData.Rows.Count;
                SqlData.Close();
            }
            catch (MySqlException ex)
            {
                Log.Message(LogType.ERROR, "{0}", ex.Message);
            }

            return retData;
        }
    }
}
