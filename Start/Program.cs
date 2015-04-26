using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using AlgorithmLib.Sort;
using Start.QueueStackTest;

namespace Start
{
    class Program
    {
        static void Main(string[] args)
        {
            var queueStackTester = new QueueStackTester();
            queueStackTester.Test();
        }
    }
}
