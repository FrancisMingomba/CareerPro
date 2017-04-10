using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerPro.Logic
{
    public class JobManager : IJobManager
    {
        public List<DataObjects.Question> Questions
        {
            get { throw new NotImplementedException(); }
        }

        public List<DataObjects.JobPosition> JobPositions
        {
            get { throw new NotImplementedException(); }
        }

        public List<DataObjects.Question> RetrieveQuestionsByJobId(int id)
        {
            throw new NotImplementedException();
        }

        public List<DataObjects.JobPosition> RetrieveJobPositions()
        {
            throw new NotImplementedException();
        }
    }
}
