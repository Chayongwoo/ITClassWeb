using System;
using System.Collections.Generic;

namespace ITClassWeb.Models
{
    public class Lecture
    {
        public int LectureID { get; set; }
        public string LectureTitle { get; set; }
        public string LectureLanguage { get; set; }
        public string LectureImage { get; set; }
        public string TutorIntroduce { get; set; }
        public string LectureIntroduce { get; set; }
        public string LecturePeople { get; set; }
        public string LecturePlan { get; set; }
        public int LectureCount { get; set; }
        public int LecturePrice { get; set; }
        public int LectureMaxperson { get; set; }
        public DateTime LectureApplyDeadline { get; set; }
        public string LectureLocation { get; set; }
        public string LecturePlace { get; set; }
        public int MemberID { get; set; }

        public virtual ICollection<Application> Application { get; set; }
        public virtual Member Member { get; set; }
        public virtual ICollection<Review> Review { get; set; }
        public virtual ICollection<Schedule> Schedule { get; set; }
    }
}