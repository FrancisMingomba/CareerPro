using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerPro.DataObjects
{
    public class ApplicationComposite
    {
        public CareerRegisterViewModel RegisterViewModel { get; set; }

        public IEnumerable<Question> Questions { get; set; }

    }
}
