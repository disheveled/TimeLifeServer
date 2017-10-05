using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Lifetime;
using System.Collections.Generic;
using System.Diagnostics;
using TimeLifeLibrary;


namespace TimeLifeLibrary
{
    public class SponsorManager : MarshalByRefObject
    {
        public List<TableDataClientSponsor> SponsorsList;
        public ILease currentLease;
    

       public SponsorManager(TableData table)
        {

            Console.WriteLine(value: DateTime.Now + " - Спонсор манагер активирован");
            SponsorsList = new List<TableDataClientSponsor>();
            currentLease = (ILease)RemotingServices.GetLifetimeService(table);


        }
        public void Register(TableDataClientSponsor sponsor)
        {
            Console.WriteLine(value: DateTime.Now + " - Регистрация");
           // Debug.Assert(currentLease.CurrentState == LeaseState.Active);
            currentLease.Register(sponsor);
            lock (this)
            {
                Console.WriteLine(value: DateTime.Now + " - Добавили");
                SponsorsList.Add(sponsor);
            }
        }

  
        public void Unregister(TableDataClientSponsor obj)
        {
            
            Debug.Assert(currentLease.CurrentState == LeaseState.Active);
            currentLease.Unregister(obj);
            lock (this)
            {
                SponsorsList.Remove(obj);
            }
        }
        


        public void UnregisterAll() {
            lock (this)
            {
                while (SponsorsList.Count > 0)
                {

                    TableDataClientSponsor sponsor = SponsorsList[0];
                    currentLease.Unregister(sponsor);
                    SponsorsList.RemoveAt(0);
                }
            }
        }

        public int SponsorsCount() {

            return SponsorsList.Count;
        }
    }
}
