using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Lifetime;
using TimeLifeLibrary;

namespace TimeLifeClient
{
    class MainClient
    {
        static void Main(string[] args)
        {

            RemotingConfiguration.Configure("TimeLifeClient.exe.config", false);

            TableData table = new TableData();
            
            Console.WriteLine(DateTime.Now + " - 5 + 2 = {0}", table.Add(5, 2));
            Console.WriteLine(DateTime.Now + " - 5 + 2 = {0}", table.Add(1, 2));
            Console.WriteLine(DateTime.Now + " - 5 + 2 = {0}", table.Add(3, 2));

            TableDataClientSponsor sp = new TableDataClientSponsor(table);
            table.manager.Register(sp);
            Console.WriteLine(DateTime.Now + " - Зарегистрирован Спонсор на удаление для WKO");
            Console.ReadLine();

            Console.ReadLine();
            User user = new User("Ololosha");
            ILease leaseInfo = (ILease)user.GetLifetimeService();
            Console.WriteLine(DateTime.Now + leaseInfo.CurrentLeaseTime.ToString());
            leaseInfo.Register(new UserClientSponsor());
            Console.ReadLine();

        }
    }
}
