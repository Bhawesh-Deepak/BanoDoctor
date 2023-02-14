using BanoDoctor.UI.DomainModel.Inquiry;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanoDoctor.UI.DomainModel
{
    public class BDContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=122.176.55.107,1433; Database=BanoDoctor; User Id=sa;Password =vi@pra91", optionsBuilder => optionsBuilder.EnableRetryOnFailure());
        }

        public virtual DbSet<InquiryModel> InquiryModel { get; set; }
    }
}
