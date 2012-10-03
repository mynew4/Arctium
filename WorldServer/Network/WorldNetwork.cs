using System;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using Framework.Logging;
using WorldServer.Game.Managers;

namespace WorldServer.Network
{
    public class WorldNetwork
    {
        public volatile bool listenSocket = true;
        TcpListener listener;

        public bool Start(string host, int port)
        {
            try
            {
                listener = new TcpListener(IPAddress.Parse(host), port);
                listener.Start();

                return true;
            }
            catch (Exception e)
            {
                Log.Message(LogType.ERROR, "{0}", e.Message);
                Log.Message();

                return false;
            }
        }

        public void AcceptConnectionThread()
        {
            new Thread(AcceptConnection).Start();
        }
 
        async void AcceptConnection()
        {
            while (listenSocket)
            {
                Thread.Sleep(1);
                if (listener.Pending())
                {
                    WorldClass worldClient = new WorldClass();
                    worldClient.clientSocket = await listener.AcceptSocketAsync();

                    new Thread(worldClient.OnConnect).Start();
                }
            }
        }
    }
}
