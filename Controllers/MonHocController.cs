using System.Linq;
using System.Web.Mvc;
using WebTruong.Models;


namespace WebTruong.Controllers
{
    public class MonHocController : Controller
    {
        QLDKMHEntities db = new QLDKMHEntities();
        // GET: MonHoc
        public ActionResult Index()
        {
            var subjects = db.Subjects.ToList(); // Lấy danh sách Subject từ DB
            return View(subjects);               // Truyền danh sách vào View
        }
        public ActionResult IndexStudent()
        {
            var subjects = db.Subjects.ToList(); // Lấy danh sách Subject từ DB
            return View(subjects);               // Truyền danh sách vào View
        }
        public ActionResult IndexCustomer()
        {
            var subjects = db.Subjects.AsQueryable();

            return View(subjects.ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.listCate = new SelectList(db.Departments, "DeptCode", "DeptName");
            return View();
        }
        public ActionResult Create(Subject st)
        {
            ViewBag.listCate = new SelectList(db.Departments, "DeptCode", "DeptName");
            if (ModelState.IsValid)
            {
                // Nếu không muốn xử lý ảnh, bỏ toàn bộ đoạn sau
                // if (pro.ImagePath != null)
                // {
                //     string fileName = Path.GetFileNameWithoutExtension(pro.ImagePath.FileName);
                //     string extention = Path.GetExtension(pro.ImagePath.FileName);
                //     fileName = fileName + extention;
                //     pro.ImagePath.SaveAs(Path.Combine(Server.MapPath("~/Anh/"), fileName));
                //     pro.ImagePro = "~/Anh/" + fileName;
                // }

                db.Subjects.Add(st);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(st);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.listCate = new SelectList(db.Departments, "DeptCode", "DeptName");
            var st = db.Subjects.Find(id);
            return View(st);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Subject st)
        {
            ViewBag.listCate = new SelectList(db.Departments, "DeptCode", "DeptName");
            var stEdit = db.Subjects.Find(st.SubjectID);
         
            //if (stEdit == null)
            //{
            //    return HttpNotFound();
            //}
            if (ModelState.IsValid)
            {
                stEdit.SubjectName = st.SubjectName;
                stEdit.DeptCode = st.DeptCode;
                stEdit.Credits = st.Credits;
                stEdit.StartDate = st.StartDate;
                stEdit.ClassTime = st.ClassTime;
                stEdit.Capacity = st.Capacity;
                stEdit.Classroom = st.Classroom;


                //if (pro.ImagePath != null)
                //{
                //    string fileName = Path.GetFileNameWithoutExtension(pro.ImagePath.FileName);
                //    string extention = Path.GetExtension(pro.ImagePath.FileName);
                //    fileName = fileName + extention;
                //    pro.ImagePath.SaveAs(Path.Combine(Server.MapPath("~/Anh/"), fileName));
                //    proEdit.ImagePro = "~/Anh/" + fileName;

                //}
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(st);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            ViewBag.listCate = new SelectList(db.Departments, "DeptCode", "DeptName");
            var pro = db.Subjects.Find(id);
            return View(pro);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Subject st, int id)
        {
            try
            {
                ViewBag.listCate = new SelectList(db.Departments, "DeptCode", "DeptName");

                var proDelete = db.Subjects.Find(id);
                if (proDelete != null)
                {
                    db.Subjects.Remove(proDelete);
                    db.SaveChanges();
                    ViewBag.errDelete = null;
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                ViewBag.errDetete = "Môn này không thể xóa";

            }
            return View(st);
        }


    }
}