using System;
using System.Collections.Generic;
using System.Threading;
using Tracer;
using Tracer.Serialization;
namespace TracerAppForTests
{
    class Program
    {
        static ITracer tracer;
        private static List<Thread> threadList;

        static void Main(string[] args)
        {
            TraceResult result = DoCalculations();

            ISerialize jSONSerializer = new JSONSerializer();
            ISerialize xMLSerializer = new XMLSerializer();
            string json = jSONSerializer.Serialize(result);
            string xml = xMLSerializer.Serialize(result);

            IWriter writer = new FileWriter("out.xml");
            writer.OutPut(xml);
            IWriter writer3 = new FileWriter("out.json");
            writer3.OutPut(json);

            IWriter writer2 = new ConsoleWriter();
            writer2.OutPut(json);
            Console.WriteLine("==================================================");
            writer2.OutPut(xml);

            Console.ReadLine();
        }

        static private TraceResult DoCalculations()
        {
            tracer = new SomeTracer();
            MakeThreads();

            while (tracer.GetTraceResult() == null)
            {
                Thread.Sleep(50);
            }
            return tracer.GetTraceResult();
        }

        static void MakeThreads()
        {
            threadList = new List<Thread>();

            for (int i = 0; i < 3; i++)
            {
                if (i % 2 == 0)
                {
                    Thread thread = new Thread(SomeMeth) { IsBackground = true };
                    threadList.Add(thread);
                    thread.Start();
                }
                else
                {
                    Thread thread = new Thread(SomeMeth2) { IsBackground = true };
                    threadList.Add(thread);
                    thread.Start();
                }
            }

            foreach (Thread thread in threadList)
            {
                thread.Join();
            }
        }

        static private void SomeMeth()
        {
            tracer.StartTrace();
            Thread.Sleep(100);
            int i = Thread.CurrentThread.ManagedThreadId % 2 + 1;
            SomeMeth1(ref i);
            SomeMeth2();
            tracer.StopTrace();
        }

        static private void SomeMeth1(ref int i)
        {
            tracer.StartTrace();
            i--;
            Thread.Sleep(200);
            while (i >= 1)
            {
                SomeMeth1(ref i);
            }
            if (Thread.CurrentThread.ManagedThreadId % 2 == 1)
            {
                SomeMeth2();
            }
            else
            {
                SomeMeth3();
            }
            tracer.StopTrace();
        }

        static private void SomeMeth2()
        {
            tracer.StartTrace();
            Thread.Sleep(300);
            Random random = new Random();
            for (int i = random.Next(3); i < 3; i++)
            {
                SomeMeth3();
            }
            tracer.StopTrace();
        }

        static private void SomeMeth3()
        {
            tracer.StartTrace();
            Thread.Sleep(50);
            tracer.StopTrace();
        }

    }
}
