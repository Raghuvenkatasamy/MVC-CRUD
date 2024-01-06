using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer;

namespace MVCwithCRUD.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: RegistrationController
        public ActionResult Index()
        {
            return View("RegistrationPage");
        }

        // GET: RegistrationController/Details/5
        public ActionResult Authentication(Registration reg)
        {
            if (reg.UserName != )
            {
                ModelState.AddModelError("DateofMaufacture", "DOM should be less than today");
                return View("Create", values);
            }
            if (ModelState.IsValid)
            {
                _mDtl.InsertMVC(values);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View("Create", values);
            }
            return View();
        }

        // GET: RegistrationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RegistrationController/Create
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

        // GET: RegistrationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RegistrationController/Edit/5
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

        // GET: RegistrationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RegistrationController/Delete/5
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
