using ITClassWeb.DAL;
using ITClassWeb.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Windows;

namespace ITClassWeb.Controllers
{
    public class MemberController : Controller
    {
        static int nansuNumber = 0;

        private ClassContext db = new ClassContext();

        // GET: Member
        public ActionResult Index()
        {
            return View(db.Members.ToList());
        }

        // GET: Member/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // GET: Member/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Member/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MemberID,MemberName,MemberEmail,MemberPassword,ConfirmPassword,MemberPhone,MemberType,TutorImage,TutorPortfolio,TutorGit")] Member member)
        {
            var lst = new List<Member>();

            var query = from x in db.Members
                        where x.MemberEmail.Equals(member.MemberEmail)
                        select x;

            lst.AddRange(query);

            if (lst.Count != 0)
            {
                MessageBox.Show("이미 존재하는 이메일 입니다.");
                return View();
            }

            if (ModelState.IsValid)
            {
                db.Members.Add(member);
                db.SaveChanges();
                return RedirectToAction("SignIn", "Member");
            }

            return View("Create");
        }

        // GET: Member/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View("Edit", member);
        }

        // POST: Member/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MemberID,MemberName,MemberEmail,MemberPassword,ConfirmPassword,MemberPhone,MemberType,TutorImage,ImageMimeType,TutorPortfolio,TutorGit")] Member member)
        {

            if (ModelState.IsValid)
            {
                db.Entry(member).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(member);
        }

        // GET: Member/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            return View(member);
        }

        // POST: Member/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Member member = db.Members.Find(id);
            db.Members.Remove(member);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn([Bind(Include = "MemberID,MemberName,MemberEmail,MemberPassword,ConfirmPassword,MemberPhone,MemberType,TutorImage,TutorPortfolio,TutorGit")] Member member)
        {
            var lst = new List<Member>();

            var query = from x in db.Members
                        where x.MemberEmail.Equals(member.MemberEmail) && x.MemberPassword.Equals(member.MemberPassword)
                        select x;

            lst.AddRange(query);

            if (lst.Count != 0)
            {
                Session["MemberEmail"] = lst[0].MemberEmail;
                Session["MemberName"] = lst[0].MemberName;
                Session["MemberID"] = lst[0].MemberID;
                Session["MemberType"] = lst[0].MemberType;

                return RedirectToAction("Index", "Home");
            }
            else
            {
                MessageBox.Show("로그인에 실패했습니다. 다시 로그인해주세요.");
                return View();
            }
        }
        public ActionResult SignOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult TutorRegister()
        {

            if (Session["MemberID"] == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Member member = db.Members.Find(Session["MemberID"]);
            if (member == null)
            {
                return HttpNotFound();
            }

            member.ConfirmPassword = member.MemberPassword;

            return View(member);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TutorRegister([Bind(Include = "MemberID,MemberName,MemberEmail,MemberPassword,ConfirmPassword,MemberPhone,MemberType,TutorImage,ImageMimeType,TutorPortfolio,TutorGit")] Member member, HttpPostedFileBase image = null)
        {
            MessageBox.Show(member.ConfirmPassword);

            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    member.ImageMimeType = image.ContentType;
                    member.TutorImage = new byte[image.ContentLength];
                    image.InputStream.Read(member.TutorImage, 0, image.ContentLength);
                }

                db.Entry(member).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(member);
        }

        public FileContentResult GetImage(int MemberID)
        {
            Member member = db.Members.FirstOrDefault(p => p.MemberID == MemberID);
            if (member != null)
                return File(member.TutorImage, member.ImageMimeType);
            else
                return null;
        }

        public ActionResult FindPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FindPassword(Member objUser)
        {
            using (ClassContext db = new ClassContext())
            {

                var obj = db.Members.Where(a => a.MemberEmail.Equals(objUser.MemberEmail) && a.MemberName.Equals(objUser.MemberName) && a.MemberPhone.Equals(objUser.MemberPhone)).FirstOrDefault();

                var memberList = new List<Member>();

                var member = from x in db.Members
                             where x.MemberEmail == objUser.MemberEmail
                             && x.MemberName == objUser.MemberName && x.MemberPhone == objUser.MemberPhone
                             select x; // obj == member

                memberList.AddRange(member);

                Member mem = memberList[0];

                if (obj != null)
                {
                    SendEmail(obj.MemberEmail);
                }

                return View("Verify", mem);
            }
        }

        [HttpPost]
        public ViewResult SendEmail(string memberEmail)
        {
            int number = Nansu();

            MailMessage mail = new MailMessage();
            mail.To.Add(memberEmail);
            mail.From = new MailAddress("corsair920825@gmail.com");
            mail.Subject = "ITTaling 인증 코드";
            string Body = number.ToString();
            mail.Body = Body;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new System.Net.NetworkCredential("corsair920825@gmail.com", "tkxkd1357!!@"); // Enter seders User name and password  
            smtp.EnableSsl = true;
            smtp.Send(mail);

            nansuNumber = number;

            return View("Index", number);
        }

        public int Nansu()
        {
            Random ran = new Random();

            int number = 0;
            for (int i = 1; i < 7; i++)
            {
                number += ran.Next(1, 9);
                number = number * 10;
            }

            nansuNumber = number;

            return number;
        }

        public ActionResult Verify(Member mem)
        {
            Member member = db.Members.Find(mem.MemberID);

            return View(member);
        }

        [HttpPost]
        public ActionResult Verify(Member mem, string id)
        {
            if (id != null)
            {
                if ((nansuNumber.ToString()).Equals(id))
                {
                    Member member = db.Members.Find(mem.MemberID);

                    return View("NewPasswordView", member);
                    //return View("NewPassword",mem.memberID.ToString());
                }
                else
                {
                    MessageBox.Show("인증번호 일치하지않음");
                    return View();
                }
            }
            else
            {
                MessageBox.Show("메일전송 실패");
                return View();
            }
        }
    }
}
