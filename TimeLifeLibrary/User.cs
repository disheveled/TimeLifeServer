using System;

// CAO

namespace TimeLifeLibrary 
{
    public class User : MarshalByRefObject, IDisposable
    {
        string mstring;
        public User(string str) {

            Console.Write("Создан САО объект с именем {0}",str);
            mstring = str;
        }

        public void Dispose()
        {
            Console.WriteLine("Объект САО удалён.");
            GC.SuppressFinalize(this);
        }
          ~User()
        {
            Console.WriteLine("Вызов деструктора.");   }
        }
}
