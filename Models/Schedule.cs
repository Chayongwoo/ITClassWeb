using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ITClassWeb.Models
{
    public class Schedule
    {
        public int ScheduleID { get; set; }

        [Display(Name = "강의 요일")]
        [Required(ErrorMessage = "강의 요일을 입력해야 합니다..")]
        [StringLength(10)]
        public string Dayofweek { get; set; }

        [Display(Name = "강의 시간")]
        [Required(ErrorMessage = "강의 시간를 입력해야 합니다.")]
        [StringLength(20)]
        public string ScheduleTime { get; set; }


        public int LectureID { get; set; }

        public virtual Lecture Lecture { get; set; }
    }
}