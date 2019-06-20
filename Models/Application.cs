using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITClassWeb.Models
{
    public class Application
    {
        public int ApplicationID { get; set; }
        public string ApplicationLevel { get; set; }
        public int LectureID { get; set; }
        public int MemberID { get; set; }

        public virtual Lecture Lecture { get; set; }
        public virtual ICollection<ApplySchedule> ApplySchedule { get; set; }
    }
}