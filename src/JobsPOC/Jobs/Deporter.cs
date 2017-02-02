using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace JobsPOC.Jobs
{
    public static class Deporter
    {
        public static void Execute()
        {
            var rand = new Random(1);
            var min = rand.Next(3, 10);
            min = min * 60 * 1000;
            Thread.Sleep(min);
        }
    }
}
