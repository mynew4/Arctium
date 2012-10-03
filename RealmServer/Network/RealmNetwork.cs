using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Framework.Logging;

namespace Framework.Network.Realm
{
    public class RealmNetwork
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
                    RealmClass realmClient = new RealmClass();
                    realmClient.clientSocket = await listener.AcceptSocketAsync();

                    new Thread(realmClient.Recieve).Start();
                }
            }
        }
    }
}
