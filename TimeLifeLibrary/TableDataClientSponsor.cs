using System;
using System.Runtime.Remoting.Lifetime;
using TimeLifeLibrary;


namespace TimeLifeLibrary
{
    public class TableDataClientSponsor : MarshalByRefObject, ISponsor
    {
        public  TableData mManagedObj;
        private int count = 0;

        public TableDataClientSponsor (TableData managedObj)
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
            else
            {
                Console.WriteLine(value: DateTime.Now + " - Не добавляем RenewOnCall к WKO");

                if (mManagedObj.manager.SponsorsCount() == 1) {

                    mManagedObj.Dispose();
                    Console.WriteLine(value: DateTime.Now + " - DISPOSE!!!");
                    mManagedObj.manager.Unregister(this);
                }
                mManagedObj.manager.Unregister(this);
                return TimeSpan.FromSeconds(0);

               

            }


        


        }

    }
}
