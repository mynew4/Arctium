using System;
using System.Data;

namespace Framework.Database
{
    public class SQLResult : DataTable
    {
        public int Count { get; set; }

        public T Read<T>(int row, string columnName)
        {
            return (T)Convert.ChangeType(Rows[row][columnName], typeof(T));
        }
    }
}
