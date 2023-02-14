using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BanoDoctor.Admin.UI.Domains
{
    [Table("Inquiry", Schema = "ContactUs")]
    public class InquiryModel: BaseModel<int>
    {
        public string CandidateName { get; set; }
        public string CandidateEmail { get; set; }
        public string CandidatePhone { get; set; }
        public string SelectedCourse { get; set; }
        public string Message { get; set; }
    }
}
