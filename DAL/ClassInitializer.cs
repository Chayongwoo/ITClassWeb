using ITClassWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITClassWeb.DAL
{
    public class ClassInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ClassContext>
    {
        protected override void Seed(ClassContext context)
        {
            var members = new List<Member>
            {
                new Member{MemberEmail="abcd",MemberName="abc",MemberPassword="1234",MemberPhone="1234",MemberType="abc"}
            };

            members.ForEach(s => context.Members.Add(s));
            context.SaveChanges();

            var licenses = new List<License>
            {
                new License{LicenseAcqDate=DateTime.Parse("2019-06-19"),LicenseAgency="abc",LicenseName="qwerty",LicenseNumber="234546"}
            };
            licenses.ForEach(s => context.Licenses.Add(s));
            context.SaveChanges();
        }
    }
}