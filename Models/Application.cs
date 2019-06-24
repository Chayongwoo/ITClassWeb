using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ITClassWeb.Models
{
    public class Application
    {
        public int ApplicationID { get; set; }

        [Display(Name = "자신의 레벨")]
        [Required(ErrorMessage = "레벨을 선택해야 합니다.")]
        public string ApplicationLevel { get; set; }


        public int LectureID { get; set; }
        public int MemberID { get; set; }

        public virtual Lecture Lecture { get; set; }
        public virtual ICollection<ApplySchedule> ApplySchedule { get; set; }
    }
}