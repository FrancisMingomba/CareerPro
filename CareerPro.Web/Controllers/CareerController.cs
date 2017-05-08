using CareerPro.DataObjects;
using CareerPro.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CareerPro.Web.Controllers
{
    public class CareerController : Controller
    {
        IQuestionManager _questionManger = new QuestionManager();
        ApplicantManager _applicantManager = new ApplicantManager();

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
        public ActionResult ApplicationQuestions(ApplicationComposite compositeData)
        {
            //store informati

            return View("Success");


            //return View();
        } 

        [HttpPost]
        public ActionResult Register(CareerRegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Apply");
            }

            //stores information to database
            bool success = _applicantManager.CreateApplicant(model);

            //stores in identity table and logs you in

            
            if (success)
            {
                var previousFormData = new CareerRegisterViewModel { JobPosition = 1, JobName = model.JobName };

                var compositeModel = new ApplicationComposite();
                compositeModel.RegisterViewModel = previousFormData;

                try
                {
                    compositeModel.Questions = _questionManger.RetrieveQuestions();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw;
                }

                return View("ApplicationQuestions", compositeModel); 

            }
            else
            {
                return View("Error");
            }
            //setting job id and job name from previous form
            
        }
    }
}