using System;
using System.Threading;

namespace JobsPOC.Jobs
{
    public static class QueueProcessor
    {
        public static void Execute(string id)
        {
            var rand = new Random(1);
            var min = rand.Next(3, 10);
            min = min * 60 * 1000;
            Thread.Sleep(min);
        }
    }
}
