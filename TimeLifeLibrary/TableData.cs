using System;


namespace TimeLifeLibrary
{
    public class TableData : MarshalByRefObject, IDisposable
    {
        public TableData() {

            Console.WriteLine(value: DateTime.Now + " - Создана главная таблица с данными.");
           


        }

        public int Add(int n1, int n2)
        {
            Console.WriteLine(DateTime.Now + " - SimpleMath.Add({0}, {1})", n1, n2);
            return n1 + n2;
        }

        public void Dispose()
        {
            Console.WriteLine(value: DateTime.Now + " - Объект WKO удалён.");
            GC.SuppressFinalize(this);
        }
        ~TableData()
        {
            Console.WriteLine(value: DateTime.Now + " - Вызов деструктора.");
            Console.ReadLine();
        }
    }


}

