using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BanoDoctor.Admin.UI.Domains
{

	[Table("CandidateDetails")]
    public class CandidateDetailModel: BaseModel<int>
    {
		public string RollCode { get; set; }
		public string RLRW { get; set; }
		public string ApplicationNumber { get; set; }
		public string CandidateName { get; set; }
		public string MotherName { get; set; }
		public string FatherName { get; set; }
		public string StatusCode { get; set; }
		public string MobileNumber { get; set; }
		public string Nationality { get; set; }
		public string DateOfBirth { get; set; }
		public string Gender { get; set; }
		public string CategoryName { get; set; }
		public string PH { get; set; }
		public string Total { get; set; }
		public string NEETRank { get; set; }
		public string NEET_CAT_RANK { get; set; }
		public string APPState { get; set; }
		public string AppState_N { get; set; }
		public string CenterNumber { get; set; }
	}
}
