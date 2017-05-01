using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CareerPro.DataObjects;
using CareerPro.DataAccess;

namespace CareerPro.Logic
{
    public class QuestionManager : IQuestionManager
    {
        public List<Question> RetrieveQuestions()
        {
            return QuestionAccessor.RetrieveQuestions();
        }
    }
}
