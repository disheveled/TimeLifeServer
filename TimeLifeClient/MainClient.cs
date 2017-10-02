using System;
using System.Runtime.Remoting;
using TimeLifeLibrary;

namespace TimeLifeClient
{
    class MainClient
    {
        static void Main(string[] args)
        {

            RemotingConfiguration.Configure("TimeLifeClient.exe.config", false);

            TableData table = new TableData();
            Console.WriteLine(value: DateTime.Now + " - На клиенте попытка создать объект WKO");
            Console.ReadLine();
            Console.WriteLine(DateTime.Now + " - 5 + 2 = {0}", table.Add(5, 2));
            Console.WriteLine(DateTime.Now + " - 5 + 2 = {0}", table.Add(1, 2));
            Console.WriteLine(DateTime.Now + " - 5 + 2 = {0}", table.Add(3, 2));

            Console.ReadLine();

            User user = new User("ololo");
           
            Console.ReadLine();
        }
    }
}
