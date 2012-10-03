using WorldServer.Game.PacketHandler;
using Framework.Constants;
using WorldServer.Game.Packets.PacketHandler;

namespace Framework.Network.Packets
{
    public class HandlerDefinitions
    {
        public static void Initialize()
        {
            PacketManager.DefineOpcodeHandler(ClientMessage.TransferInitiate, AuthenticationHandler.HandleTransferInitiate);
            PacketManager.DefineOpcodeHandler(ClientMessage.AuthSession, AuthenticationHandler.HandleAuthSession);
            PacketManager.DefineOpcodeHandler(ClientMessage.EnumCharacters, CharacterHandler.HandleCharacterEnum);
            PacketManager.DefineOpcodeHandler(ClientMessage.RequestCharCreate, CharacterHandler.HandleRequestCharCreate);
            PacketManager.DefineOpcodeHandler(ClientMessage.RequestCharDelete, CharacterHandler.HandleRequestCharDelete);
            PacketManager.DefineOpcodeHandler(ClientMessage.PlayerLogin, CharacterHandler.HandlePlayerLogin);
            PacketManager.DefineOpcodeHandler(ClientMessage.ReadyForAccountDataTimes, TimeHandler.HandleReadyForAccountDataTimes);
            PacketManager.DefineOpcodeHandler(ClientMessage.RequestUITime, TimeHandler.HandleRequestUITime);
            PacketManager.DefineOpcodeHandler(ClientMessage.RequestRandomCharacterName, CharacterHandler.HandleRequestRandomCharacterName);
            #region Chat
            PacketManager.DefineOpcodeHandler(ClientMessage.ChatMessageSay, ChatHandler.HandleChatMessageSay);
            #endregion
            #region Logout
            PacketManager.DefineOpcodeHandler(ClientMessage.Logout, LogoutHandler.HandleLogout);
            #endregion
        }
    }
}
