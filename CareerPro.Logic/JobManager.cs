using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerPro.DataObjects;

namespace CareerPro.Logic
{
    public class JobManager : IJobManager
    {
        public List<Question> Questions
        {
            get { throw new NotImplementedException(); }
        }

        public List<JobPosition> JobPositions
        {
            get { throw new NotImplementedException(); }
        }

        public List<Question> RetrieveQuestionsByJobId(int id)
        {
            throw new NotImplementedException();
        }

        public List<JobPosition> RetrieveJobPositions()
        {
            throw new NotImplementedException();
        }
    }
}
