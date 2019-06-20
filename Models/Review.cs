using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITClassWeb.Models
{
    public class Review
    {
        public int ReviewID { get; set; }
        public string ReviewContent { get; set; }
        public int ReviewGrade { get; set; }
        public int LectureID { get; set; }
        public int MemberID { get; set; }

        public virtual Lecture Lecture { get; set; }

    }
}