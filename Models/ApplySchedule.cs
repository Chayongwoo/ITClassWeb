using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITClassWeb.Models
{
    public class ApplySchedule
    {
        public int ApplyScheduleID { get; set; }
        public string ApplyDayofweek { get; set; }
        public string ApplyScheduleTime { get; set; }
        public int ApplicationID { get; set; }

        public virtual Application Application { get; set; }
    }
}