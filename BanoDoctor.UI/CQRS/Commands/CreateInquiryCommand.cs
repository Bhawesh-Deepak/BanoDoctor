using MediatR;
using System.ComponentModel.DataAnnotations;

namespace BanoDoctor.UI.CQRS.Commands
{
    public class CreateInquiryCommand:IRequest<bool>
    {
        [Required(ErrorMessage ="Candidate name is required !")]
        public string CandidateName { get; set; }
        [Required(ErrorMessage = "Candidate email is required !")]
        public string CandidateEmail { get; set; }
        [Required(ErrorMessage = "Candidate phone is required !")]
        public string CandidatePhone { get; set; }
        [Required(ErrorMessage = "Please select course is required !")]
        public string SelectedCourse { get; set; }
        [Required(ErrorMessage = "Please select course is required !")]
        public string Message { get; set; }
    }
}
