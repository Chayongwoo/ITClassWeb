using System;

namespace ITClassWeb.Models
{
    public class License
    {
        public int LicenseID { get; set; }
        public string LicenseName { get; set; }
        public string LicenseAgency { get; set; }
        public DateTime LicenseAcqDate { get; set; }
        public string LicenseNumber { get; set; }
        public int MemberID { get; set; }

        public virtual Member Member { get; set; }
    }
}