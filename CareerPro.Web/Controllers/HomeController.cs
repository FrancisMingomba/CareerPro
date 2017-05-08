using CareerPro.DataObjects;
using CareerPro.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CareerPro.Web.Controllers
{
    public class HomeController : Controller
    {
        IJobManager _jobManager = new JobManager();
        List<Job> jobs = new List<Job>();

        /// <summary>
        /// Renders jobs to user to choose
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            RetrieveJobs(); 
            return View(jobs);
        }
        

        /// <summary>
        /// Renders job details to user
        /// 
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        public ActionResult JobDetail(int? jobId)
        {
            RetrieveJobs();
            var job = jobs.FirstOrDefault(x => x.Id == jobId);

            if (job == null)
                return View("Error");

            return View(job);
        }

        /// <summary>
        /// Renders main application for personal information
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Apply(int id)
        {
            RetrieveJobs();
            var job = jobs.FirstOrDefault(x => x.Id == id);

            var r = new CareerRegisterViewModel
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

        public void  RetrieveJobs()
        {
            try
            {
                jobs = _jobManager.RetrieveJobs();
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}