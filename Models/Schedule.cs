using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITClassWeb.Models
{
    public class Schedule
    {
        public int ScheduleID { get; set; }
        public string Dayofweek { get; set; }
        public string ScheduleTime { get; set; }
        public int LectureID { get; set; }

        public virtual Lecture Lecture { get; set; }
    }
}