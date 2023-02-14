using System.ComponentModel.DataAnnotations.Schema;


namespace BanoDoctor.UI.DomainModel.Inquiry
{
    [Table("Inquiry", Schema ="ContactUs")]
    public class InquiryModel: BaseModel
    {
        public string CandidateName { get; set; }
        public string CandidateEmail { get; set; }
        public string CandidatePhone { get; set; }
        public string SelectedCourse { get; set; }
        public string Message { get; set; }
    }
}
