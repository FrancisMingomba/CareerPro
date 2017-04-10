using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerPro.DataObjects
{
    public class Question
    {
        public int Id { get; set; }
        
        public string QxnString { get; set; }

        public string TextAnswer { get; set; }

        public int JobPositionId { get; set; }
    }
}
