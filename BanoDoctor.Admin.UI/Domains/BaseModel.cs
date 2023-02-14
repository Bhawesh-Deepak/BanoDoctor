using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BanoDoctor.Admin.UI.Domains
{
    public class BaseModel<T>
    {
        public T Id { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
