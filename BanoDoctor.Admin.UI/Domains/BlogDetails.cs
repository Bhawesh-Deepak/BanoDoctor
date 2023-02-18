using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BanoDoctor.Admin.UI.Domains
{
    [Table("BlogDetails", Schema = "Blogs")]
    public class BlogDetails: BaseModel<int>
    {
        public string CreatedBy { get; set; } = "Admin";
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string Heading { get; set; }
        public string BlogDescription { get; set; }
        public bool Ispublished { get; set; }
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaLink { get; set; }
        public string ImagePath { get; set; }
        public string ImageAltTage { get; set; }
        [NotMapped]
        public IFormFile UploadImage { get; set; }
    }
}
