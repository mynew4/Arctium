using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Framework.Logging;

namespace Framework.DBC
{
    public class DBCLoader
    {
        public static void Init()
        {
            Log.Message(LogType.NORMAL, "Loading DBCStorage...");
            DBCStorage.RaceStorage = DBCReader.ReadDBC<ChrRaces>(DBCStorage.RaceStrings, DBCFmt.ChrRacesEntryfmt, "ChrRaces.dbc");
            DBCStorage.ClassStorage = DBCReader.ReadDBC<ChrClasses>(null, DBCFmt.ChrClassesEntryfmt, "ChrClasses.dbc");
            DBCStorage.CharStartOutfitStorage = DBCReader.ReadDBC<CharStartOutfit>(null, DBCFmt.CharStartOutfitfmt, "CharStartoutfit.dbc");
            DBCStorage.NameGenStorage = DBCReader.ReadDBC<NameGen>(DBCStorage.NameGenStrings, DBCFmt.NameGenfmt, "NameGen.dbc");

            Log.Message(LogType.NORMAL, "Loaded {0} dbc files.", DBCStorage.DBCFileCount);
            Log.Message();
        }
    }
}
