using BanoDoctor.UI.DomainModel.Inquiry;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanoDoctor.UI.CQRS.Queries
{
    public class GetInquiryDetailCommand: IRequest<List<InquiryModel>>
    {
    }
}
