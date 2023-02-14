using BanoDoctor.Admin.UI.Domains;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanoDoctor.Admin.UI.CQRS.Queries
{
    public class GetInquiryQuery: IRequest<List<InquiryModel>>
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
