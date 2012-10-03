using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Logging;

namespace Framework.DBC
{
    public class DB2Loader
    {
        public static void Init()
        {
            Log.Message(LogType.NORMAL, "Loading DB2Storage...");
            DB2Storage.ItemEntryStorage = DB2Reader.ReadDB2<ItemEntry>(null, DB2Fmt.Itemfmt, "Item.db2");

            Log.Message(LogType.NORMAL, "Loaded {0} db2 files.", DB2Storage.DB2FileCount);
            Log.Message();
        }
    }
}
