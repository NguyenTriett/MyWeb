using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebTruong.Models;

namespace WebTruong.Controllers
{
    public class LoginController : Controller
    {
        QLDKMHEntities db = new QLDKMHEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Admin adminUser)
        {
            var checkID = db.Admins.Where(s => s.ID.Equals(adminUser.ID)).FirstOrDefault();
            var checkPass = db.Admins.Where(s => s.PasswordUser.Equals(adminUser.PasswordUser)).FirstOrDefault();

            if (checkID == null)
            {
                ViewBag.ErrLoginID = "Sai ID";
                return View();
            }
            if (checkPass == null)
            {
                ViewBag.ErrLoginPass = "Sai mat khau";
                return View();
            }
            if (checkID != null && checkPass != null)
            {
                Session["ID"] = adminUser.ID;
                Session["RoleUser"] = adminUser.RoleUser;
                // Thêm dòng này để lưu tên người dùng
                Session["NameUser"] = checkID.NameUser;

                if (Session["RoleUser"].ToString() == "admin")
                    return RedirectToAction("Index", "MonHoc");
                else return RedirectToAction("IndexStudent", "MonHoc");


            }
            return View("Index", "Login");
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }

        public ActionResult Register()
        {
            return View();
        }
        //Xac thuc dang ky
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Admin adminUser)
        {
            var checkID = db.Admins.Where(s => s.ID == adminUser.ID).FirstOrDefault();
            if (checkID != null)
            {
                ViewBag.ErrorRegister = "Trùng ID";
                return View("Register");
            }
            else
            {
                if (!ModelState.IsValid)
                {
                    db.Admins.Add(adminUser);
                    db.SaveChanges();
                    return RedirectToAction("Index", "Login");
                }
            }

            return View();
        }

    }
}