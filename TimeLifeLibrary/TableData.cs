using System;
using System.Runtime.Remoting.Lifetime;


namespace TimeLifeLibrary
{
    public class TableData : MarshalByRefObject, IDisposable
    {


        public SponsorManager manager;

        public TableData() {

            Console.WriteLine(value: DateTime.Now + " - Создана главная таблица с данными.");
            manager = new SponsorManager(this);
            Console.WriteLine(value: DateTime.Now + " - Создан спонсор-менеджер.");

        }

       

        public int Add(int n1, int n2)
        {
            Console.WriteLine(DateTime.Now + " - SimpleMath.Add({0}, {1})", n1, n2);
            return n1 + n2;
        }

        public void Dispose()
        {



            ILease leaseinfo = (ILease)this.GetLifetimeService();
            if (leaseinfo.CurrentState.ToString() == "Active")
            {

                Console.WriteLine(value: DateTime.Now + " - Не удаляем ничо т.к. объект еще эктив.");
                return;
            }
            else
            {
                Console.WriteLine(value: DateTime.Now + " - Вызываем Dispose(true).");

                GC.SuppressFinalize(this);


            }
        }
            
        



        ~TableData()
        {
            Console.WriteLine(value: DateTime.Now + " - Вызов финализатора WKO объекта.");
            Console.ReadLine();
        }
    }


}

