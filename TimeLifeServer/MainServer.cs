using System;
using System.Runtime.Remoting;

namespace TimeLifeServer
{
    class MainServer
    {
        static void Main(string[] args)
        {
            RemotingConfiguration.Configure("TimeLifeServer.exe.config", false);
         
            Console.WriteLine(value: DateTime.Now + " - Сервер запущен. Ожидает соединения!");
            Console.ReadLine();


        }
    }
}
