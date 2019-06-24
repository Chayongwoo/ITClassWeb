using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ITClassWeb.Models
{
    public class Review
    {
        public int ReviewID { get; set; }

        [Display(Name = "리뷰 내용")]
        [Required(ErrorMessage = "내용을 입력해야 합니다.")]
        [StringLength(200, ErrorMessage = "최대 200자까지 작성할 수 있습니다.")]
        public string ReviewContent { get; set; }

        [Display(Name = "평점")]
        [Required(ErrorMessage = "평점을 입력해야 합니다.")]
        [RegularExpression(@"[1-5]{1}$",ErrorMessage ="평점은 1~5점만 줄 수 있습니다.")]
        public int ReviewGrade { get; set; }


        public int LectureID { get; set; }
        public int MemberID { get; set; }

        public virtual Lecture Lecture { get; set; }

    }
}