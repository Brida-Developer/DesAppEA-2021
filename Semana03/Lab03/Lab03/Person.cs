using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab03
{
    class Person
    {
        public int PersonID { get; internal set; }
        public string LastName { get; internal set; }
        public string FirstName { get; internal set; }
        public string HireDate { get; internal set; }

        public DateTime EnrollmentDate { get; internal set; }

    }
}
