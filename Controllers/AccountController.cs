using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using StudentInformationSystem.Properties;

namespace StudentInformationSystem.Controllers
{
    public class AccountController : Controller
    {
        private StudentsEntities db = new StudentsEntities();

        // GET: Account/Login
        public ActionResult Login()
        {
            return View();
        }
        // POST: Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "Aid,Apassword")] Administrator administrator)
        {
            int uid = administrator.Aid;
            String upass = administrator.Apassword;
            //String uname = administrator.Aname;
            Administrator admin = db.Administrator.Find(uid);
            if (admin !=null)
            {
                if (upass.Equals(admin.Apassword))
                {
                    //登陆成功把用户名和id存入session
                    Session["username"] = admin.Aname.ToString();
                    Session["userid"] = admin.Aid;
                    //返回网站首页
                    return RedirectToAction("../Home/Index");
                }    
            }
            return View();
        }
        //
        public ActionResult Infor()
        {
            return View();
        }
        // GET: Account/Signin
        public ActionResult Signin()
        {
            return View();
        }

        // POST: Account/Signin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Signin([Bind(Include = "Aid,Apassword,Aname")] Administrator administrator)
        {
            if (ModelState.IsValid)
            {
                db.Administrator.Add(administrator);
                db.SaveChanges();
                return RedirectToAction("Login");
            }

            return View(administrator);
        }

        // GET: Account/Logout
        public ActionResult Logout()
        {
            //删除Session对象
            Session.Remove("username");
            //返回网站首页
            return RedirectToAction("../Home/Index");
        }

        // GET: Account/EditPassword
        public ActionResult EditPassword()
        {
            String uname = Session["username"].ToString();
            int id = (int)Session["userid"];
            Administrator administrator = db.Administrator.Find(id);
            if (administrator == null)
            {
                return HttpNotFound();
            }
            return View(administrator);
        }

        // POST: Account/EditPassword
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditPassword([Bind(Include = "Aid,Aname,Apassword")] Administrator administrator)
        {
            if (ModelState.IsValid)
            {
                db.Entry(administrator).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(administrator);
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
