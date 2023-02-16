using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BanoDoctor.Admin.UI.Domains
{
    [Table("UserDetail", Schema = "UserManagement")]
    public class UserModel: BaseModel<int>
    {
        [Required(ErrorMessage ="Employee name is required !")]
        public string EmployeeName { get; set; }

        [Required(ErrorMessage = "Employee code is required !")]
        public string EmployeeCode { get; set; }
        [Required(ErrorMessage = "Role is required !")]
        public string Designation { get; set; }
        [Required(ErrorMessage ="User name is required !")]
        public string UserName { get; set; }
        [Required(ErrorMessage ="Password is required !")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
       

        [Required(ErrorMessage ="Confirm password is required!")]
        [Compare("Password")]
        [NotMapped]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Email is required !")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Phone is required !")]
        public string Phone { get; set; }

    }

}
