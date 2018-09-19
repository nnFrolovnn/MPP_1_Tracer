using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tracer;
namespace UnitTests
{
    [TestClass]
    public class UnitTestForTracer
    {
        ITracer tracer;
        TraceResult result;

        [TestInitialize]
        public void Init()
        {
            tracer = new SomeTracer();
            Method1();
            result = tracer.GetTraceResult();
        }

        [TestMethod]
        public void TestMethodsName()
        {
            string expectedName = "Method1";
            if (result.TraceThreads.Count == 0)
            {
                Assert.Fail("no traced threads in thread list");
            }
            else
            {
                if (result.TraceThreads[0].Methodslist.Count == 0)
                {
                    Assert.Fail("no traced methods in method list");
                }
                else
                {
                    Assert.AreEqual(expectedName, result.TraceThreads[0].Methodslist[0].Method);
                }
            }
        }

        [TestMethod]
        public void TestThreadId()
        {
            long expectedId = Thread.CurrentThread.ManagedThreadId;
            if (result.TraceThreads.Count == 0)
            {
                Assert.Fail("no traced threads in thread list");
            }
            else
            {
                Assert.AreEqual(expectedId, result.TraceThreads[0].Id);
            }
        }

        [TestMethod]
        public void TestMethodsClassName()
        {
            string expectedName = "UnitTestForTracer";
            if (result.TraceThreads.Count == 0)
            {
                Assert.Fail("no traced threads in thread list");
            }
            else
            {
                if (result.TraceThreads[0].Methodslist.Count == 0)
                {
                    Assert.Fail("no traced methods in method list");
                }
                else
                {
                    Assert.AreEqual(expectedName, result.TraceThreads[0].Methodslist[0].Class);
                }
            }
        }

        [TestMethod]
        public void TestExecutionTime()
        {            
            if (result.TraceThreads.Count == 0)
            {
                Assert.Fail("no traced threads in thread list");
            }
            else
            {
                long expectedTime = 1400;
                if (expectedTime > result.TraceThreads[0].Executiontime)
                {
                    Assert.Fail("expected time is greater then actual");
                }
                
            }
        }

        private void Method1()
        {
            tracer.StartTrace();
            System.Threading.Thread.Sleep(100);
            Method2(true);
            Method4(false);
            tracer.StopTrace();
        }

        private void Method2(bool next)
        {
            tracer.StartTrace();
            System.Threading.Thread.Sleep(200);
            if (next)
            {
                Method3();
            }
            else
            {
                Method4(true);
            }
            tracer.StopTrace();
        }

        private void Method3()
        {
            tracer.StartTrace();
            System.Threading.Thread.Sleep(300);
            tracer.StopTrace();
        }

        private void Method4(bool next)
        {
            tracer.StartTrace();
            System.Threading.Thread.Sleep(400);
            if (next)
            {
                Method3();
            }
            else
            {
                Method4(true);
            }
            tracer.StopTrace();
        }
    }
}
