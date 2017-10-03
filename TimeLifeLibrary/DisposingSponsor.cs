using System;
using System.Runtime.Remoting.Lifetime;

namespace TimeLifeLibrary
{
    class DisposingSponsor : ISponsor
    {
        private IDisposable mManagedObj;
        public DisposingSponsor(IDisposable managedObj)
        {
            mManagedObj = managedObj;
        }
        public TimeSpan Renewal(ILease leaseInfo)
        {
            mManagedObj.Dispose();
            Console.WriteLine(value: DateTime.Now + " - Вызван метод серверного спонсора ");
            return TimeSpan.FromSeconds(0);
        }
    }
}
