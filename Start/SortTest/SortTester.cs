using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlgorithmLib.Sort;

namespace Start.SortTest
{
    public class SortTester : ITest
    {
        public void Test()
        {
            var list = new List<int>()
            {
                6,3,3,6,4,12,343,45,47,65,8,56,45,
            };

            var sortService = new SortService<int>(list, (i, i1) => (i > i1));

            foreach (var value in sortService.GetSortedListByQuickSort())
            {
                Console.Write(value + "  ");
            }
        }
    }
}
