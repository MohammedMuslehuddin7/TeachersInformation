using System;
using System.Collections.Generic;

namespace MVC1.Models
{
    public partial class StudentClass
    {
        public int StudentClassId { get; set; }
        public int? ClassId { get; set; }
        public int? StudentId { get; set; }

        public Class Class { get; set; }
        public StudentsDb Student { get; set; }
    }
}
