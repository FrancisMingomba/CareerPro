using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerPro.DataObjects
{
    public class Question
    {
        public int Id { get; set; }
        
        [Required]
        public string QxnString { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string TextAnswer { get; set; }

    }
}
