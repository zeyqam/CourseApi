﻿using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Teacher:BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public decimal Salary { get; set; }
        public int Age { get; set; }
        public ICollection<TeacherGroup> TeacherGroups { get; set; }
    }
}
