using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompareAttribute = System.ComponentModel.DataAnnotations.CompareAttribute;

namespace ITClassWeb.Models
{

    public class Member
    {
        public int MemberID { get; set; }

        [Display(Name = "이름")]
        [Required(ErrorMessage = "이름을 입력해야 합니다.")]
        [StringLength(20, ErrorMessage = "이름은 최대 20자리입니다.")]
        [RegularExpression(@"[가-힣]*$", ErrorMessage = "이름은 한글로 입력하세요.")]
        public string MemberName { get; set; }

        [Display(Name = "이메일")]
        [Required(ErrorMessage = "이메일을 입력해야 합니다.")]
        [StringLength(30, ErrorMessage = "이메일은 최대 30자리입니다.")]
        [RegularExpression(@"[\w_]+\@[\w]+\.[\w]+", ErrorMessage = "잘못된 이메일입니다.")]
        public string MemberEmail { get; set; }

        [Display(Name = "전화번호")]
        [Required(ErrorMessage = "전화번호를 입력해야 합니다.")]
        [StringLength(20)]
        [RegularExpression(@"^01[0|1|6|7|8|9]{1}[\d]{3,4}\d{4}$", ErrorMessage = "잘못된 전화번호입니다.(-는 제외하고 입력하세요.)")]
        public string MemberPhone { get; set; }

        [Display(Name = "비밀번호")]
        [Required(ErrorMessage = "비밀번호를 확인해야 합니다.")]
        [StringLength(15, ErrorMessage = "비밀번호는 8~15자리여야 합니다.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [RegularExpression(@"[\w\!\@\^\*]+", ErrorMessage = "특수문자는 !,@,^,*만 사용할 수 있습니다.")]
        public string MemberPassword { get; set; }

        [Display(Name ="비밀번호 확인")]
        [NotMapped]
        [Compare("MemberPassword")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        [Display(Name = "회원 유형")]
        public string MemberType { get; set; }

        [Display(Name ="본인 사진")]
        public byte[] TutorImage { get; set; }

        public string ImageMimeType { get; set; }

        [Display(Name ="포트폴리오", Description = "포트폴리오를 하나의 압축파일로 올려주세요.")]
        [DataType(DataType.Upload)]
        public string TutorPortfolio { get; set; }

        [Display(Name = "Git 주소")]
        [DataType(DataType.Url)]
        [RegularExpression(@"https?://(\w*:\w*@)?[-\w.]+(:\d+)?(/([\w/_.]*(\?\S+)?)?)?$")]
        public string TutorGit { get; set; }

        public virtual ICollection<License> Licenses { get; set; }
    }
}