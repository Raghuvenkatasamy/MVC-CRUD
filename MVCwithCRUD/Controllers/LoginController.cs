using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace MVCwithCRUD.Controllers
{
    public class logindlt
    {
        public string Email { get; set; }
        public string Password { get; set; }

    }
    public class LoginController : Controller
    {
        private readonly string _Email;
        private readonly string _password;
       
        public LoginController(IConfiguration configuration)
        {
            _Email = configuration.GetValue<string>("Login:Username");
            _password = configuration.GetValue<string>("Login:PasswordKey");
           
        }
        // GET: LoginController1
        public ActionResult Index()
        {
            return View("LoginPage");
        }


        //validation
        public ActionResult Authentication(logindlt log)
        {
            try
            {
                
                if (log.Email ==_Email && log.Password ==_password)
                {
                    return Redirect("/Mobiledlt/index");
                }
                else
                {
                    ModelState.AddModelError("Password","Invalid Email or password");
                    return View("LoginPage");
                }
            
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: LoginController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LoginController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoginController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LoginController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LoginController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LoginController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LoginController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
