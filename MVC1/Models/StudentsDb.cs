using System;
using System.Collections.Generic;

namespace MVC1.Models
{
    public partial class StudentsDb
    {
        public StudentsDb()
        {
            StudentClass = new HashSet<StudentClass>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public int? Salary { get; set; }

        public EmployeePersonalInfo EmployeePersonalInfo { get; set; }
        public ICollection<StudentClass> StudentClass { get; set; }
    }
}
