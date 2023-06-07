using SignUpWithLoginMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SignUpWithLoginMVC.Controllers
{
    public class LoginController : Controller
    {

        SignupLoginEntities db = new SignupLoginEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(user u)
        {
            var user = db.users.Where(model => model.username == u.username && model.passsword == u.passsword).FirstOrDefault();
            if(user != null)
            {
                Session["UserId"] = u.Id.ToString();
                Session["Username"] = user.username.ToString();
                TempData["LoginSuccessMessage"] = "<script>alert('Login Successfully ..!!')</script>";
                return RedirectToAction("Index", "User");

            }
            else
            {
                ViewBag.ErrorMessage = "<script>alert('Username or Password is Incorrect ..!!')</script>";
                return View();

            }
        }


        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Signup(user u)
        {
            if (ModelState.IsValid==true)
            {
                db.users.Add(u);
               int a =  db.SaveChanges();
                if(a>0)
                {
                    ViewBag.InsertMessage = "<script>alert('Registered Successfully')</script>";
                    ModelState.Clear();
                }
                else
                {
                    ViewBag.InsertMessage = "<script>alert('Registration Failed')</script>";

                }

            }
            return View();
        }

    }
}