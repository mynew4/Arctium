namespace Framework.Constants
{
    public enum AccountDataTypes
    {
        GlobalConfigCache             = 0x0,
        CharacterConfigCache          = 0x1,
        GlobalBindingsCache           = 0x2,
        CharacterBindingsCache        = 0x3,
        GlobalMacrosCache             = 0x4,
        CharacterMacrosCache          = 0x5,
        CharacterLayoutCache          = 0x6,
        CharacterChatCache            = 0x7
    }

    public enum AccountDataMasks
    {
        GlobalCacheMask               = 0x15,
        CharacterCacheMask            = 0xAA
    }
}
