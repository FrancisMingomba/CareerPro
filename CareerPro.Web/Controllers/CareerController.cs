using CareerPro.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CareerPro.Web.Controllers
{
    public class CareerController : Controller
    {
        List<Question> questions = new List<Question>{
                new Question { Id = 1, QxnString = "What is favorite dog", TextAnswer = ""},
                new Question { Id = 2, QxnString = "What is your deepest interest", TextAnswer = "" },
                new Question { Id = 3, QxnString = "What is your motivation", TextAnswer = ""},
                new Question { Id = 4, QxnString = "What is your complexion", TextAnswer = "" },
                new Question { Id = 5, QxnString = "What is your nature", TextAnswer = "" }
            };



        // GET: CareerPro
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Submits Job Application Data
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ApplicationQuestions(IEnumerable<Question> questions)
        {
            //store informati


            return View();
        } 

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Apply");
            }

            //stores information to database

            //stores in identity table and logs you in

            //based on success, user is routed to custom questions
            //if (success) == go to home/applicationsQuestions
            //if (fail) == return current View

            var a = new ApplicationComposite();

            var b = new RegisterViewModel { JobPosition = 1, JobName = model.JobName };

            a.RegisterViewModel = b;
            a.Questions = questions;

            return View("ApplicationQuestions", a); 
        }
    }
}