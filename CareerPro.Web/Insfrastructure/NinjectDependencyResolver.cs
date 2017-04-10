using CareerPro.DataObjects;
using CareerPro.Logic;
using Moq;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CareerPro.Web.Insfrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();

        }

        public object GetService(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            Mock<IJobManager> mock = new Mock<IJobManager>();
            mock.Setup(m => m.JobPositions).Returns(new List<JobPosition>{
                new JobPosition { Name = "Java Programmer", Description = "Programs in Java", Id = 1 },
                new JobPosition { Name = "C# Programmer", Description = "Programs in C#", Id = 2 },
                new JobPosition { Name = "Python Programmer", Description = "Programs in Python", Id = 3 },
                new JobPosition { Name = "Data Scientist", Description = "Analyses data", Id = 4 }
            });

            Mock<IJobManager> mock2 = new Mock<IJobManager>();
            mock2.Setup(m => m.Questions).Returns(new List<Question>{
                new Question { Id = 1, QxnString = "What is favorite dog", TextAnswer = "", JobPositionId = 1 },
                new Question { Id = 2, QxnString = "What is your deepest interest", TextAnswer = "", JobPositionId = 2 },
                new Question { Id = 3, QxnString = "What is your motivation", TextAnswer = "", JobPositionId = 3 },
                new Question { Id = 4, QxnString = "What is your complexion", TextAnswer = "", JobPositionId = 4 },
                new Question { Id = 5, QxnString = "What is your nature", TextAnswer = "", JobPositionId = 1 }
            });

            kernel.Bind<IJobManager>().ToConstant(mock.Object);
        }
    }
}