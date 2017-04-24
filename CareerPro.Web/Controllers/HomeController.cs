using CareerPro.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CareerPro.Web.Controllers
{
    public class HomeController : Controller
    {
        //Will leave really soon
        List<JobPosition> jobs = new List<JobPosition>{
                new JobPosition { Name = "Java Programmer", Description = "Programs in Java", Id = 1 },
                new JobPosition { Name = "C# Programmer", Description = "Programs in C#", Id = 2 },
                new JobPosition { Name = "Python Programmer", Description = "Programs in Python", Id = 3 },
                new JobPosition { Name = "Data Scientist", Description = "Analyses data", Id = 4 }
            };

        /// <summary>
        /// Renders jobs to user to choose
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View(jobs);
        }

        public ActionResult Apply(int id)
        {
            var job = jobs.FirstOrDefault(x => x.Id == id);

            var r = new RegisterViewModel
            {
                JobPosition = id,
                JobName = job.Name
            };

            return View(r);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}