using System;
using System.Runtime.Remoting.Lifetime;

namespace TimeLifeServer
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
            return TimeSpan.FromSeconds(0);
        }
    }
}
