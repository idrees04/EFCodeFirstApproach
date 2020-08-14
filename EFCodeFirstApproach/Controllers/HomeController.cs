using EFCodeFirstApproach.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

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
                    TempData["InsertMewssage"] = "Data Inserted ";
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
        public ActionResult Edit(int id)
        {
            // this mathod will take to Edit View
            // if model of id is equal to database of student id then  FirstOrDefault() method will store row in (var row).
            var row = db.students.Where(model => model.Id == id).FirstOrDefault();
            return View(row);
        }
        [HttpPost]
        public ActionResult Edit(Student s)
        {
            // HttpPost method of Edit will update data to database
            // this method will run wihen we will click on Edit button
            if (ModelState.IsValid == true)
            {
                db.Entry(s).State = EntityState.Modified;
                int a = db.SaveChanges();
                if (a > 0)
                {
                    //ViewBag.UpdateMessage = "<script>alert('Data Updated')</script>";
                    // ModelState.Clear();
                    TempData["UpdateMewssage"] = "Data Updated ";
                    return RedirectToAction("autoGenratedView");
                }
                else
                {
                    ViewBag.UpdateMessage = "<script>alert('Data Not Updated')</script>";
                }
            }
                return View();
        }
        public ActionResult Delete(int id)
        {
            // this mathod will take to delete View

            if (id > 0)
            {
                var StudentIdRow = db.students.Where(model => model.Id == id).FirstOrDefault();
                if(StudentIdRow != null)
                {
                    db.Entry(StudentIdRow).State = EntityState.Deleted;
                    int a=db.SaveChanges();
                    if(a>0)
                    {
                        TempData["DeleteMessage"] = "Data Deleted";
                    }
                    else
                    {
                        TempData["DeleteMessage"] = "<script>alert('Data Not Deleted')</script>";
                    }                 
                }
            }
            return RedirectToAction("autoGenratedView");
        }

    }
}