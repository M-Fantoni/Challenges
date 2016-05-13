using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace testAlgo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("start working");

            var worker = new Worker();

            worker.DoWork();

            while (!worker.IsComplete)
            {
                Console.Write(".");
                Thread.Sleep(100);
            }
            Console.WriteLine("done");

            #region oldtest
            //List<Func<int, string>> FonctionsTest = new List<Func<int, string>>();

            //FonctionsTest.Add(f => { return ((f % 3) == 0) ? "fizz" : null; });
            //FonctionsTest.Add(f => { return ((f % 5) == 0) ? "buzz" : null; });
            //FonctionsTest.Add(f => { return ((f % 5) == 0) && ((f % 3) == 0) ? "fizz buzz" : null; });

            //string result = string.Empty;
            //for (int i = 1; i <= 100; i++)
            //{
            //    foreach (var item in FonctionsTest)
            //    {
            //        if (item(i) != null)
            //        {
            //            result = item(i);
            //        }
            //    }
            //    if (result != string.Empty)
            //    {
            //        Console.WriteLine(result);
            //        result = string.Empty;
            //    }
            //    else
            //    {
            //        Console.WriteLine(i);
            //    }

            //}

            //Dictionary<Func<int, bool>, string> Tests = new Dictionary<Func<int, bool>, string>();

            //Tests.Add(x => { return (x % 3) == 0; }, "fizz");
            //Tests.Add(x => { return (x % 5) == 0; }, "buzz");
            //Tests.Add(x => { return (x % 15) == 0; }, "fizz buzz");

            //string res = String.Empty;
            //for (int i = 0; i < 100; i++)
            //{
            //    res = Convert.ToString(i);
            //    foreach (var item in Tests)
            //    {

            //        if (item.Key(i))
            //        {
            //            res = item.Value;
            //        }

            //    }
            //    Console.WriteLine(res);
            //}



            //for (int i = 0; i < 100; i++)
            //{


            //Console.WriteLine("combien de parfaits ?");
            //int HowManyResults = Convert.ToInt32(Console.ReadLine());
            //int NumberToTest = 1;
            //bool TestCompleted = false;

            //List<long> Divisors = new List<long>();
            //List<long> PrimeNumber = new List<long>();
            //long Sum = 0;
            //PerfectNumberTests Tests = new PerfectNumberTests();

            //while(TestCompleted == false)
            //{
            //    Divisors = Tests.GetAllDivisor(NumberToTest);
            //    Sum = Tests.Sum(Divisors);
            //    if (Tests.IsItPerfect(NumberToTest, Sum))
            //    {
            //        PrimeNumber.Add(NumberToTest);
            //        Console.WriteLine(NumberToTest);
            //    }
            //    NumberToTest++;
            //    if (HowManyResults == PrimeNumber.Count())
            //        TestCompleted = true;
            //}
            #endregion 
            Console.Read();
        }

        

    }

    internal class Worker
    {
        public Worker()
        {
        }

        public bool IsComplete { get; internal set; }

        internal async void DoWork()
        {
            this.IsComplete = false;

            Console.WriteLine("Doing work");

            await LongOperation();

            Console.WriteLine("work completed");

            IsComplete = true;
        }

        private Task LongOperation()
        {
            return Task.Factory.StartNew(() => {
                Console.WriteLine("Working");
                Thread.Sleep(2000);
            } );
            
        }
    }
}
