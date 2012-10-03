using Db4objects.Db4o;
using Db4objects.Db4o.CS;
using Db4objects.Db4o.Linq;
using Framework.Logging;
using System;

namespace Framework.Database
{
    public class ObjectDataBase
    {
        public IObjectContainer Connection;
        public int RowCount { get; set; }

        public void Connect(string host, int port, string user, string password)
        {
            Connection = Db4oClientServer.OpenClient(host, port, user, password);// Db4oEmbedded.OpenFile("Database/" + db + ".yap");
        }

        public bool Save(object obj)
        {
            try
            {
                Connection.Store(obj);
                Connection.Commit();

                return true;
            }
            catch (Exception ex)
            {
                Log.Message(LogType.ERROR, "{0}", ex.Message);
                return false;
            }
        }

        public bool Delete(object obj)
        {
            try
            {
                Connection.Delete(obj);
                Connection.Commit();

                return true;
            }
            catch (Exception ex)
            {
                Log.Message(LogType.ERROR, "{0}", ex.Message);
                return false;
            }
        }

        public IDb4oLinqQuery Select<T>()
        {
            var sObject = from T o in Connection select o;

            int count = 0;
            foreach (object o in sObject)
                ++count;

            RowCount = count;

            return sObject;
        }
    }
}
