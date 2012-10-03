using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.DBC
{
    public static class DBCStorage
    {
        internal static int DBCFileCount = 0;

        public static Dictionary<uint, ChrClasses> ClassStorage;
        public static Dictionary<uint, ChrRaces> RaceStorage;
        public static Dictionary<uint, CharStartOutfit> CharStartOutfitStorage;
        public static Dictionary<uint, NameGen> NameGenStorage;

        //Strings
        internal static Dictionary<uint, string> ClassStrings = new Dictionary<uint, string>();
        internal static Dictionary<uint, string> RaceStrings = new Dictionary<uint, string>();
        internal static Dictionary<uint, string> NameGenStrings = new Dictionary<uint, string>();
    }
}
