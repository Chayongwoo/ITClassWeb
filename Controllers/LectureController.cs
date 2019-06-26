using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Windows;
using ITClassWeb.DAL;
using ITClassWeb.Models;

namespace ITClassWeb.Controllers
{
    public class LectureController : Controller
    {
        private ClassContext db = new ClassContext();

        // GET: Lecture
        public ActionResult Index()
        {
            var lectures = db.Lectures.Include(l => l.Member);
            return View(lectures.ToList());
        }

        // GET: Lecture/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lecture lecture = db.Lectures.Find(id);
            if (lecture == null)
            {
                return HttpNotFound();
            }
            return View(lecture);
        }

        // GET: Lecture/Create
        public ActionResult Create()
        {
            if(Session["MemberID"] != null)
            {
                ViewBag.MemberID = (int)Session["MemberID"];
                return View("Create");
            }
            else
            {
            MessageBox.Show("로그인을 하셔야 작성하실 수 있습니다.");
            return RedirectToAction("Index");

            }
           // ViewBag.MemberID = new SelectList(db.Members, "MemberID", "MemberName");
        }

        public ActionResult LectureBoardList(string lectureLanguage)
        {

            var lectures = db.Lectures.Where(l => l.LectureLanguage == lectureLanguage);


            if (lectures == null)
            {
                return HttpNotFound();
            }

            return View(lectures.ToList());
        }

       




        // POST: Lecture/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LectureID,LectureTitle,LectureLanguage,LectureImage,LectureImageName,LectureImageType,TutorIntroduce,LectureIntroduce,LecturePeople,LecturePlan,LectureCount,LecturePrice,LectureMaxperson,LectureApplyDeadline,LectureLocation,LecturePlace,ScheduleTime,MemberID")] Lecture lecture, HttpPostedFileBase image = null)
        {

            if (ModelState.IsValid)
            {

                if (image != null)
                {
                    lecture.LectureImageName = image.FileName; // 파일명
                    lecture.LectureImageType = image.ContentType;
                    if(lecture.LectureImage != null)
                    {
                    lecture.LectureImage = new byte[image.ContentLength];
                    }
                    else
                    {
                        MessageBox.Show("파일을 업로드 해주세요.");
                        return View();
                    }

                    image.InputStream.Read(lecture.LectureImage, 0, image.ContentLength);
                }
                
                db.Lectures.Add(lecture);
                db.SaveChanges();

                Session["LectureID"] = lecture.LectureID;

                return RedirectToAction("Index");
            }

            return View();
        }

        public FileContentResult GetImage(int LectureID)
        {
            Lecture lecture = db.Lectures.FirstOrDefault(p => p.LectureID == LectureID);
            if (lecture != null)
                return File(lecture.LectureImage, lecture.LectureImageName);
            else
                return null;
        }




        // GET: Lecture/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lecture lecture = db.Lectures.Find(id);
            if (lecture == null)
            {
                return HttpNotFound();
            }
            ViewBag.MemberID = new SelectList(db.Members, "MemberID", "MemberName", lecture.MemberID);
            return View(lecture);
        }

        // POST: Lecture/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LectureID,LectureTitle,LectureLanguage,LectureImage,TutorIntroduce,LectureIntroduce,LecturePeople,LecturePlan,LectureCount,LecturePrice,LectureMaxperson,LectureApplyDeadline,LectureLocation,LecturePlace,MemberID")] Lecture lecture)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lecture).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MemberID = new SelectList(db.Members, "MemberID", "MemberName", lecture.MemberID);
            return View(lecture);
        }

        // GET: Lecture/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lecture lecture = db.Lectures.Find(id);
            if (lecture == null)
            {
                return HttpNotFound();
            }
            return View(lecture);
        }

        // POST: Lecture/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Lecture lecture = db.Lectures.Find(id);
            db.Lectures.Remove(lecture);
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
    }
}
