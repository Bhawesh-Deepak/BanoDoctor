using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanoDoctor.UI.ViewModel
{
    public class BlogModel
    {
        public int Id { get; set; }
        public string CreatedBy { get; set; } = "Admin";
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string Heading { get; set; }
        public string BlogDescription { get; set; }
        public bool Ispublished { get; set; }
    }
}
