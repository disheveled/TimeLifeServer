using System;
using System.Runtime.Remoting.Lifetime;
using TimeLifeLibrary;


namespace TimeLifeClient
{
    class TableDataClientSponsor : MarshalByRefObject, ISponsor
    {
        private IDisposable mManagedObj;
        private int count = 0;
        public TableDataClientSponsor(IDisposable managedObj)
        {
            mManagedObj = managedObj;
            Console.WriteLine(value: DateTime.Now + " - Создан WKO спонсор");

        }
        public TimeSpan Renewal(ILease leaseInfo)
        {

            if (count == 0)
            {
                count++;
                
                Console.WriteLine(value: DateTime.Now + " - Добавлено RenewOnCall к WKO");
                Console.WriteLine(value: DateTime.Now + leaseInfo.CurrentState.ToString());
                return TimeSpan.FromSeconds(leaseInfo.RenewOnCallTime.Seconds);
            }
            else {
                Console.WriteLine(value: DateTime.Now + " - Не добавляем RenewOnCall к WKO");
                if () {


                }


                return TimeSpan.FromSeconds(0);

            }

            


            //  Console.WriteLine(value: DateTime.Now + " - Вызван метод удаления для WKO.");
            //  Console.WriteLine(value: DateTime.Now + leaseInfo.CurrentState.ToString());
            //   mManagedObj.Dispose();

            //  return TimeSpan.FromSeconds(0);




        }

    }
}
