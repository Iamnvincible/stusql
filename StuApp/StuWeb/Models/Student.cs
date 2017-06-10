using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StuWeb.Models
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ClassNum { get; set; }
        public string Subject { set; get; }
        public string Sex { get; set; }
    }
}
