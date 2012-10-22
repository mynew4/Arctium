namespace Framework.ObjectDefines
{
    public class Account
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public string SessionKey { get; set; }
        public byte SecurityFlags { get; set; }
        public byte Expansion { get; set; }
        public byte GMLevel { get; set; }
        public string IP { get; set; }
        public string Language { get; set; }
    }
}
