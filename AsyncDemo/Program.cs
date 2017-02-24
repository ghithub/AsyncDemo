using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting");

            var worker = new Worker();
            worker.DoWork();

            while(!worker.IsComplete)
            {
                Console.Write(".");
                Thread.Sleep(100);
            }

            Console.WriteLine("Done");
            Console.ReadKey();
        }
    }

    public class Worker
    {
        public bool IsComplete { get; private set; }

        public async void DoWork()
        {
            this.IsComplete = false;
            Console.WriteLine("Doing work");
            await LongOperation();
            Console.WriteLine("\nWork completed");
            IsComplete = true;
        }

        private Task LongOperation()
        {
            return Task.Factory.StartNew(()=> {
                Console.WriteLine("Working!");
                Thread.Sleep(2000);
            });            
        }
    }
}
