using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Hangfire;
using JobsPOC.Jobs;
using Hangfire.Common;
using System.Diagnostics;

namespace JobsPOC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult Register()
        {
            var manager = new RecurringJobManager();

            manager.AddOrUpdate("Canoe", Job.FromExpression(() => QueueProcessor.Execute("9b4fc4c3-05cf-4e79-aa69-630d825f3872")), "* * * * *", TimeZoneInfo.Utc);

            manager.AddOrUpdate("CMA", Job.FromExpression(() => QueueProcessor.Execute("9afe149e-3648-48c4-945e-968a170307c1")), "* * * * *", TimeZoneInfo.Utc);

            manager.AddOrUpdate("CNN", Job.FromExpression(() => QueueProcessor.Execute("f1388e4f-87f7-424f-badd-c7eb037c404e")), "* * * * *", TimeZoneInfo.Utc);

            manager.AddOrUpdate("DataCity", Job.FromExpression(() => QueueProcessor.Execute("d2db802c-64c2-47e8-9612-450ad6c1e853")), "* * * * *", TimeZoneInfo.Utc);

            manager.AddOrUpdate("TitleSync", Job.FromExpression(() => TitleSyncJob.Execute()), "*/5 * * * *", TimeZoneInfo.Utc);

            manager.AddOrUpdate("Deporter", Job.FromExpression(() => Deporter.Execute()), "0 0 * * *", TimeZoneInfo.Utc);            

            RecurringJob.AddOrUpdate(
                () => Debug.WriteLine("Daily Job"), Cron.Hourly);


            return View();
        }
    }
}
