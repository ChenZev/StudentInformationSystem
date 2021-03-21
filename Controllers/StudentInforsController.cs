using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentInformationSystem.Properties;

namespace StudentInformationSystem.Controllers
{
    public class StudentInforsController : Controller
    {
        private StudentsEntities db = new StudentsEntities();

        // GET: StudentInfors
        public ActionResult Index()
        {
            return View(db.StudentInfor.ToList());
        }

        // GET: StudentInfors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentInfor studentInfor = db.StudentInfor.Find(id);
            if (studentInfor == null)
            {
                return HttpNotFound();
            }
            return View(studentInfor);
        }

        // GET: StudentInfors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentInfors/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Sno,Spassword,Sname,Ssex,Sage,Sdepartment,Smajor,Sclass,Sgpa,Scampus")] StudentInfor studentInfor)
        {
            if (ModelState.IsValid)
            {
                db.StudentInfor.Add(studentInfor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(studentInfor);
        }

        // GET: StudentInfors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentInfor studentInfor = db.StudentInfor.Find(id);
            if (studentInfor == null)
            {
                return HttpNotFound();
            }
            return View(studentInfor);
        }

        // POST: StudentInfors/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Sno,Spassword,Sname,Ssex,Sage,Sdepartment,Smajor,Sclass,Sgpa,Scampus")] StudentInfor studentInfor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentInfor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(studentInfor);
        }

        // GET: StudentInfors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentInfor studentInfor = db.StudentInfor.Find(id);
            if (studentInfor == null)
            {
                return HttpNotFound();
            }
            return View(studentInfor);
        }

        // POST: StudentInfors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StudentInfor studentInfor = db.StudentInfor.Find(id);
            db.StudentInfor.Remove(studentInfor);
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
