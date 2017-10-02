using System;
using System.Runtime.Remoting.Lifetime;


// CAO

namespace TimeLifeLibrary
{
    public class User : MarshalByRefObject, IDisposable
    {
 
        string mstring;
        public User(string str) {

            Console.WriteLine(value: DateTime.Now + " - Создан САО объект с именем " + str);

            mstring = str;
        }

        public override object InitializeLifetimeService()
        {
            ILease leaseInfo = (ILease)base.InitializeLifetimeService();
           
            // Register a DisposingSponsor object
            leaseInfo.Register(new DisposingSponsor(this));
            Console.WriteLine(value: DateTime.Now + " - Зарегистрирован спонсор на удаление.");
            // RegisterSponsors(leaseInfo);
            return leaseInfo;
        }


        public void Dispose()
        {
            Console.WriteLine(value: DateTime.Now + " - Объект САО удалён.");
            GC.SuppressFinalize(this);
        }
          ~User()
        {
            Console.WriteLine(value: DateTime.Now + " - Вызов финализатора.");   }
        }
}
