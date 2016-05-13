using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testAlgo
{
    public class PerfectNumberTests
    {
        public bool IsItPerfect(long x, long sum)
        {
            return (x == sum);
        }
        public bool IsDivisor(long NumberToTest, long diviseur)
        {
            return (NumberToTest % diviseur == 0);
        }
        public List<long> GetAllDivisor(long NumberToTest)
        {
            List<long> diviseurs = new List<long>();
            for (int i = 1; i < NumberToTest; i++)
            {
                if (IsDivisor(NumberToTest,i))
                {
                    diviseurs.Add(i);
                }
            }


            return diviseurs;
        }

        public long Sum(List<long> diviseurs)
        {
            long sum = 0;

            foreach (var item in diviseurs)
            {
                sum += item;
            }

            return sum;
        }
    }
}
