using CareerPro.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerPro.Logic
{
    public interface IQuestionManager
    {
        List<Question> RetrieveQuestions();
    }
}
