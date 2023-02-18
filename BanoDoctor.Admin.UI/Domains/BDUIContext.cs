using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanoDoctor.Admin.UI.Domains
{
    public class BDUIContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=122.176.55.107,1433; Database=BanoDoctor; User Id=sa;Password =vi@pra91", optionsBuilder => optionsBuilder.EnableRetryOnFailure());
        }

        public virtual DbSet<InquiryModel> InquiryModel { get; set; }
        public virtual DbSet<BlogDetails> BlogDetails { get; set; }
        public virtual DbSet<CourseDetail> CourseDetails { get; set; }
        public virtual DbSet<CandidateDetailModel> CandidateDetailModels { get; set; }
        public virtual DbSet<UserModel> UserModels { get; set; }
    }
}
