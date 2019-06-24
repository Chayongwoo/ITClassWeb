using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ITClassWeb.Models
{
    public class Lecture
    {
        public int LectureID { get; set; }

        [Display(Name = "강의 제목")]
        [Required(ErrorMessage = "강의 제목을 입력해야 합니다.")]
        [StringLength(30, ErrorMessage = "강의 제목은 최대 30자리입니다.")]
        public string LectureTitle { get; set; }

        [Display(Name = "프로그래밍 언어")]
        [Required(ErrorMessage = "가르칠 프로그래밍 언어를 골라야 합니다.")]
        public string LectureLanguage { get; set; }

        [Display(Name = "강의 이미지")]
        [Required(ErrorMessage = "강의 이미지를 업로드해야 합니다.")]
        public string LectureImage { get; set; }

        [Display(Name = "튜터 소개")]
        [Required(ErrorMessage = "튜터 소개를 입력해야 합니다.")]
        [StringLength(1000, ErrorMessage = "튜터 소개는 최대 1000자여야 합니다.")]
        public string TutorIntroduce { get; set; }

        [Display(Name = "강의 소개")]
        [Required(ErrorMessage = "강의 소개를 입력해야 합니다.")]
        [StringLength(1000, ErrorMessage = "강의 소개는 최대 1000자여야 합니다.")]
        public string LectureIntroduce { get; set; }

        [Display(Name = "강의 대상")]
        [Required(ErrorMessage = "강의 대상에 대해 입력해야 합니다.")]
        [StringLength(500, ErrorMessage = "강의 대상은 최대 500자여야 합니다.")]
        public string LecturePeople { get; set; }

        [Display(Name = "강의 계획")]
        [Required(ErrorMessage = "강의 계획을 입력해야 합니다.")]
        [StringLength(3000, ErrorMessage = "강의 계획은 최대 3000자여야 합니다.")]
        public string LecturePlan { get; set; }

        [Display(Name = "총 강의 시간")]
        [Required(ErrorMessage = "총 강의 시간을 입력해야 합니다.")]
        public int LectureCount { get; set; }

        [Display(Name = "시간당 강의료")]
        [Required(ErrorMessage = "시간당 강의료 입력해야 합니다.")]
        public int LecturePrice { get; set; }

        [Display(Name = "최대 수강 인원")]
        [Required(ErrorMessage = "최대 수강 인원을 입력해야 합니다.")]
        public int LectureMaxperson { get; set; }

        [Display(Name = "강의 신청 마감일")]
        [Required]
        [DataType(DataType.DateTime, ErrorMessage = "올바른 연-월-일 형식이어야 합니다.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [RegularExpression(@"^(19|20)[\d]{2}-(0[1-9]{1}|1[012]{1})-(0[1-9]{1}|[12]{1}[0-9]{1}|3[01]{1})$", ErrorMessage = "올바른 연-월-일 형식이어야 합니다.")]
        public DateTime LectureApplyDeadline { get; set; }

        [Display(Name = "강의 위치")]
        [Required(ErrorMessage = "강의 위치를 입력해야 합니다.")]
        public string LectureLocation { get; set; }

        [Display(Name = "강의 장소")]
        [Required(ErrorMessage = "강의 장소를 입력해야 합니다.")]
        public string LecturePlace { get; set; }


        public int MemberID { get; set; }

        public virtual ICollection<Application> Application { get; set; }
        public virtual Member Member { get; set; }
        public virtual ICollection<Review> Review { get; set; }
        public virtual ICollection<Schedule> Schedule { get; set; }
    }
}