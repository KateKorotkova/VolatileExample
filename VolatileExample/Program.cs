using System;
using System.Threading;

namespace VolatileExample
{
    //как увидеть разницу:
    //1. переключиться на Release, собрать решение
    //2. запустить через F5: будем видеть все три шага
    //3. запустить через Ctrl+F5: будем видеть только первые два шага
    //4. отметить Loop как volatile, запустить через Ctrl+F5: будем видеть все три шага

    public class TestClass
    {
        public volatile bool Loop = true;

        public void SomeThread(object o1)
        {
            var o = (TestClass)o1;
            Console.WriteLine("Step 1");
            while (o.Loop)
            {

            }
            Console.WriteLine("Step 3");
        }
    }

    public class Program
    {
        static void Main(string[] args)
        {
            var test = new TestClass();
            var thread = new Thread(test.SomeThread);
            thread.Start(test);

            Thread.Sleep(20);

            test.Loop = false;

            Console.WriteLine("Step 2");
        }
    }
}