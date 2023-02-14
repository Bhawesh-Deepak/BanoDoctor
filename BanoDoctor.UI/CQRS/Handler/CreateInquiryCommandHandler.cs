using BanoDoctor.UI.CQRS.Commands;
using BanoDoctor.UI.DomainModel.Inquiry;
using BanoDoctor.UI.Service;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace BanoDoctor.UI.CQRS.Handler
{
    public class CreateInquiryCommandHandler : IRequestHandler<CreateInquiryCommand, bool>
    {
        private readonly IRepository<InquiryModel> _IInquiryRepository;

        public CreateInquiryCommandHandler(IRepository<InquiryModel> inquiryRepo)
        {
            _IInquiryRepository = inquiryRepo;
        }
        public async Task<bool> Handle(CreateInquiryCommand request, CancellationToken cancellationToken)
        {
            var response = await _IInquiryRepository.AddEntity(new InquiryModel()
            {
                CandidateEmail = request.CandidateEmail,
                CandidateName = request.CandidateName,
                CandidatePhone = request.CandidatePhone,
                SelectedCourse = request.SelectedCourse,
                Message= request.Message
            });
            return response;
        }
    }
}
