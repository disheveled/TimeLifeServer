using System;


namespace TimeLifeLibrary
{
    public class TableData : MarshalByRefObject, IDisposable
    {
        private  int leases;

        public TableData() {

            Console.WriteLine(value: DateTime.Now + " - Создана главная таблица с данными.");
            leases = 1;


        }

        public int leaseCount()
        {


            return leases;
        }

        public int Add(int n1, int n2)
        {
            Console.WriteLine(DateTime.Now + " - SimpleMath.Add({0}, {1})", n1, n2);
            return n1 + n2;
        }

        public void Dispose()
        {
            Console.WriteLine(value: DateTime.Now + " - Объект WKO удалён методом Dispose().");
            GC.SuppressFinalize(this);
        }
        ~TableData()
        {
            Console.WriteLine(value: DateTime.Now + " - Вызов финализатора WKO объекта.");
            Console.ReadLine();
        }
    }


}

