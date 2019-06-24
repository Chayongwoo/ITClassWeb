using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ITClassWeb.Models
{
    public class ApplySchedule
    {
        public int ApplyScheduleID { get; set; }

        [Display(Name = "신청 요일")]
        [Required(ErrorMessage = "강의를 듣고 싶은 요일을 선택해야 합니다.")]
        public string ApplyDayofweek { get; set; }

        [Display(Name = "신청 시간")]
        [Required(ErrorMessage = "강의를 듣고 싶은 시간을 선택해야 합니다.")]
        public string ApplyScheduleTime { get; set; }


        public int ApplicationID { get; set; }

        public virtual Application Application { get; set; }
    }
}