using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITClassWeb.Models
{
    public class Member
    {
        public int MemberID { get; set; }
        public string MemberName { get; set; }
        public string MemberEmail { get; set; }
        public string MemberPassword { get; set; }
        public string MemberPhone { get; set; }
        public string MemberType { get; set; }
        public string TutorImage { get; set; }
        public string TutorPortfolio { get; set; }
        public string TutorGit { get; set; }

        public virtual ICollection<License> Licenses { get; set; }
    }
}