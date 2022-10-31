using abccompany.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace abccompany.Controllers
{
    public class HomeController : Controller
    {
        abccompanyEntities db = new abccompanyEntities();
        // GET: Home
        public ActionResult Index()
        {
            
            return View();
        }
        public ActionResult Users()
        {
            var data = db.users.ToList();
            return View(data);
        }
        //Add User Detail
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(user userdata)
        {
            db.users.Add(userdata);
            db.SaveChanges();
            return RedirectToAction("Users");
        }
        //Edit User Detail
        public ActionResult Edit(int id) {
            var row = db.users.Where(model => model.userID == id).FirstOrDefault();
            return View(row);
        }
        [HttpPost]
        public ActionResult Edit(user userdata)
        {
            db.Entry(userdata).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Users");
        }
        //Get User Detail
        public ActionResult Detail(int id) 
        {
            var row = db.users.Where(model => model.userID == id).FirstOrDefault();
            return View(row);
        }
        //Data Delete
        public ActionResult Delete(int id)
        {
            if (id > 0) 
            {
                var deleterow = db.users.Where(model => model.userID == id).FirstOrDefault();
                if (deleterow != null)
                {
                 
                        db.Entry(deleterow).State = EntityState.Deleted;
                        db.SaveChanges();
                        return RedirectToAction("Users");
                  
                    
                }
            }
            return View();
        }

    }
}