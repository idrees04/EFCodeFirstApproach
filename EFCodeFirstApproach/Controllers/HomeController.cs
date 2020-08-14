using EFCodeFirstApproach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFCodeFirstApproach.Controllers
{
    public class HomeController : Controller
    {
        StudentContextcs db = new StudentContextcs();
        // GET: Home
        public ActionResult Index()
        {
            var data = db.students.ToList();
            return View(data);
        }
        public ActionResult autoGenratedView()
        {
            var data = db.students.ToList();
            return View(data);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student s)
        {
            if(ModelState.IsValid==true)
            {
                db.students.Add(s);
                //saveChanges() class return 0 and 1, 0 case Data not Inserted 1 case Data inserted.
                int a = db.SaveChanges();
                if (a > 0)
                {
                   // ViewBag.InsertMewssage = "<script>alert('Data Inserted !!')</script>";
                   // TempData["InsertMewssage"] = "<script>alert('Data Inserted !!')</script>";
                    TempData["InsertMewssage"] = "Data Inserted !!";
                    return RedirectToAction("autoGenratedView");
                    //ModelState.Clear();
                }
                else
                {
                    ViewBag.InsertMewssage = "<script>alert('Data not Inserted !!')</script>";
                }
            }
            
            return View();
        }
    }
}