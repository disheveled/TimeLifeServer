using System;
using System.Runtime.Remoting.Lifetime;


namespace TimeLifeClient
{
    class UserClientSponsor : MarshalByRefObject, ISponsor

    {

     private int mRenewCount = 0;

     
    public TimeSpan Renewal(ILease leaseInfo)
        {
           
            if (mRenewCount < 2)
            {
                mRenewCount++;
                Console.WriteLine(value: DateTime.Now + " - Добавление RenewOnCall к времени жизни.");
                return TimeSpan.FromSeconds(leaseInfo.RenewOnCallTime.Seconds);
                
            }
            else
            {
                Console.WriteLine(value: DateTime.Now + " - Удаление спонсора и вызов спонсора на удаление.");
                return TimeSpan.FromSeconds(0);
            }
        }

    }
}
