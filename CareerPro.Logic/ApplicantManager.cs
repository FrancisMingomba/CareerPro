using CareerPro.DataAccess;
using CareerPro.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerPro.Logic
{
    public class ApplicantManager
    {
        public bool CreateApplicant(User user)
        {
            return ApplicantAccessor.CreateApplicant(user) == 1;
        }
    }
}
