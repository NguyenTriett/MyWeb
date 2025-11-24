using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebTruong.Models;
using System.Web.Mvc;

namespace WebTruong.Controllers
{
    public class AdminController : Controller
    {
        DKMHEntities db = new DKMHEntities();
        // GET: Admin
        public ActionResult MonHoc()
        {
            return View(db.Subjects.ToList());
        }
       
       
    }
}