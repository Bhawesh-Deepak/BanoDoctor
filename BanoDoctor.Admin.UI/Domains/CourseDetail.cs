using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BanoDoctor.Admin.UI.Domains
{
    [Table("CourseDetails", Schema = "Master")]
    public class CourseDetail: BaseModel<int>
    {
        [Required(ErrorMessage ="Category Name is required !")]
        public string CategoryName { get; set; }

        [Required(ErrorMessage ="Course name is required !")]
        public string CourseName { get; set; }

        [Required(ErrorMessage ="Course Details is required !")]
        public string Detail { get; set; }
    }
}
