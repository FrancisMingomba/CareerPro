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
        List<Question> Questions { get; }

        List<JobPosition> JobPositions { get; }

        List<Question> RetrieveQuestionsByJobId(int id);

        List<JobPosition> RetrieveJobPositions();

    }
}
