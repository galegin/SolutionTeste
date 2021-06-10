using System;
using System.Threading;

namespace ConsoleAppRank
{
    class Racer
    {
        private readonly string name;

        public Racer(string name)
        {
            this.name = name;
        }

        public void Run()
        {
            Thread.Sleep(100);
            Console.WriteLine(name);
        }

        static void Main(string[] args)
        {
            Thread t1 = new Thread(new Racer("1").Run);
            Thread t2 = new Thread(new Racer("2").Run);
            Thread t3 = new Thread(new Racer("3").Run);
            Thread t4 = new Thread(new Racer("4").Run);
            Thread t5 = new Thread(new Racer("5").Run); // chega primeiro

            t5.Start();
            t3.Start();
            t1.Start();
            t3.Join();
            t2.Start();
            t1.Join();
            t4.Start();
            t2.Join();
            t4.Join();
            t5.Join();

            Console.ReadLine();
        }
    }
}