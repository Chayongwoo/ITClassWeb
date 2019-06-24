using System;
using System.ComponentModel.DataAnnotations;

namespace ITClassWeb.Models
{
    public class License
    {

        public int LicenseID { get; set; }

        [Display(Name = "자격증 명")]
        [Required(ErrorMessage = "자격증을 입력해야 합니다.")]
        [StringLength(30)]
        [RegularExpression(@"[가-힣]*$", ErrorMessage = "자격증 명을 한글로 입력하세요.")]
        public string LicenseName { get; set; }

        [Display(Name = "시행 기관")]
        [Required(ErrorMessage = "시행기관을 입력해야 합니다.")]
        [StringLength(30)]
        [RegularExpression(@"[가-힣]*$", ErrorMessage = "시행기관을 한글로 입력하세요.")]
        public string LicenseAgency { get; set; }

        [Display(Name = "취득일")]
        [Required]
        [DataType(DataType.DateTime, ErrorMessage = "올바른 연-월-일 형식이어야 합니다.")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [RegularExpression(@"^(19|20)[\d]{2}-(0[1-9]{1}|1[012]{1})-(0[1-9]{1}|[12]{1}[0-9]{1}|3[01]{1})$",ErrorMessage ="올바른 연-월-일 형식이어야 합니다.")]
        public DateTime LicenseAcqDate { get; set; }

        [Display(Name = "자격증 번호")]
        [Required(ErrorMessage = "자격증 번호를 입력해야 합니다.")]
        [StringLength(30)]
        [RegularExpression(@"[a-zA-Z0-9ㄱ-ㅎ가-힣]+$", ErrorMessage = "잘못된 형식입니다.")]
        public string LicenseNumber { get; set; }

        public int MemberID { get; set; }

        public virtual Member Member { get; set; }
    }
}