using BanoDoctor.Admin.UI.CQRS.Queries;
using BanoDoctor.Admin.UI.Domains;
using BanoDoctor.Admin.UI.Service;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BanoDoctor.Admin.UI.CQRS.Handler
{
    public class GetInquiryQueryHandler : IRequestHandler<GetInquiryQuery, List<InquiryModel>>
    {
        private readonly IRepository<InquiryModel> _IInquiryModelRepository;

        public GetInquiryQueryHandler(IRepository<InquiryModel> inquiryRepo)
        {
            _IInquiryModelRepository = inquiryRepo;
        }
        public async Task<List<InquiryModel>> Handle(GetInquiryQuery request, CancellationToken cancellationToken)
        {
            var response = await _IInquiryModelRepository.GetList(null);
            return response.ToList();
        }
    }
}
