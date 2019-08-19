using System;
using System.Collections.Generic;

namespace MVC1.Models
{
    public partial class Class
    {
        public Class()
        {
            StudentClass = new HashSet<StudentClass>();
        }

        public int ClassId { get; set; }
        public string ClassName { get; set; }

        public ICollection<StudentClass> StudentClass { get; set; }
    }
}
