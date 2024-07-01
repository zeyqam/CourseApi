using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DTOs.Admin.Groups
{
    public class TeacherGroupAddDto
    {
        public int GroupId { get; set; }
        public int TeacherId { get; set; }
    }
}
