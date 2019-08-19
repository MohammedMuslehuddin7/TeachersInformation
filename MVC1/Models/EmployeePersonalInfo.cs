using System;
using System.Collections.Generic;

namespace MVC1.Models
{
    public partial class EmployeePersonalInfo
    {
        public int Id { get; set; }
        public string HomeAddress { get; set; }
        public string ContactNumber { get; set; }

        public StudentsDb IdNavigation { get; set; }
    }
}
