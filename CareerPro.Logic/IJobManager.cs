using CareerPro.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerPro.Logic
{
    public interface IJobManager
    {
        public List<Question> Questions { get; }

        public List<JobPosition> JobPositions { get; }

        public List<Question> RetrieveQuestionsByJobId(int id);

        public List<JobPosition> RetrieveJobPositions();

    }
}
