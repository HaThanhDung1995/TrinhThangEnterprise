using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebEnterprise_2.Filters;
using WebEnterprise_2.Models;
using WebEnterprise_2.Utils;

namespace WebEnterprise_2.Controllers
{
    public class TutorController : Controller
    {
        DataContext dbc = new DataContext();
        // GET: Tutor
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(String id, String password)
        {
            var manager = dbc.Turtors.SingleOrDefault(m => m.Username == id && m.Pass == password);
            if (manager == null)
            {
                ModelState.AddModelError("", "Wrong ID!");
            }
            else
            {
                ModelState.AddModelError("", "Login Successfully!");
                XSession.Tutor = manager;
                return View();
            }

            return View();
        }
        [HttpPost]
        public ActionResult Register(Turtor model)
        {
            try
            {
                dbc.Turtors.Add(model);
                dbc.SaveChanges();
                ModelState.AddModelError("", "Regist Successfully !");
            }
            catch
            {
                ModelState.AddModelError("", "Regist Fail!");
            }
            return View();
        }
        [Authenticate]
        public ActionResult Post()
        {
            ViewBag.StudentId = new SelectList(dbc.Students, "Id", "Fullname");
            return View();
        }
        [HttpPost]
        public ActionResult Post(Report model)
        {

            ViewBag.StudentId = new SelectList(dbc.Students, "Id", "Fullname");
            var file = Request.Files["UpImage"];
            if (file != null)
            {
                model.Documents = Guid.NewGuid() + file.FileName.Substring(file.FileName.LastIndexOf("."));
                file.SaveAs(Server.MapPath("~/Documents/" + model.Documents));
            }
            else
            {
                model.Documents = "Product.png";
            }

            model.TutorId = 1;
            dbc.Reports.Add(model);
            dbc.SaveChanges();
            var list = new List<string>();
            list.Add(XSession.Tutor.Email);
            
            var body = "<h1>The new report is posted</h1>";
            var student = dbc.Students.Find(model.StudentId);
            list.Add(student.Email);
            Xmailer.Send(list, "Report", body);
            
            return RedirectToAction("Post");
        }

        public ActionResult Logout()
        {
            XSession.RemoveTutor();
            return View("Login");
        }
    }
}