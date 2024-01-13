using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer;
using Microsoft.Extensions.Configuration;

namespace MVCwithCRUD.Controllers
{
    public class RegistrationController : Controller
    {

        private readonly IRegistrationRepository _reg;
        private readonly string _configuration;
        public RegistrationController(IRegistrationRepository reg, IConfiguration configuration)
        {
            _reg = reg;
            _configuration = configuration.GetConnectionString("DbConnection");
        }
        // GET: RegistrationController
        public ActionResult Index()
        {
            return View("RegistrationPage");
        }

        public ActionResult List()
        {
            var list = _reg.GetAllRegistration();
            return View("View", list);
        }


        public ActionResult Details(int id)
        {
            try
            {
                var num = _reg.FindProductByNumber(id);
                return View("RegisterDetails", num);
            }
            catch
            {
                return View("Error");
            }
        }

        public ActionResult AuthenticationR(Registration reg)
        {
            try
            {
                var resultreg = _reg.Register(reg);


                if (resultreg == true)
                {
                    _reg.Insert(reg);

                    return Redirect("/Login/index");
                }
                else
                 {
                    ModelState.AddModelError("ConformPassword", "Already Exist");
                    return View("RegistrationPage");
                }

            }
            catch
            {
                return View("Error");
            }
        }

        // GET: RegistrationController/Create
        public ActionResult Create()
        {
            try
            {
                return View("RegisterCreate",new Registration());
            }
            catch
            {
                return View("Error");
            }
        }

        // POST: RegistrationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Registration values)
        {
            try
            {
                var resultreg = _reg.Register(values);


                if (resultreg == true)
                {
                    _reg.Insert(values);

                    var list = _reg.GetAllRegistration();
                    return View("View", list);
                }
                else
                {
                    ModelState.AddModelError("ConformPassword", "Already Exist");
                    return View("RegisterCreate",values);
                }

            }
            catch
            {
                return View("Error");
            }
        }

        // GET: RegistrationController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var num = _reg.FindProductByNumber(id);
                return View("RegisterEdit", num);
            }
            catch {
                return View("Error");
                    }
        }

        // POST: RegistrationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,Registration values)
        {
            try
            {
//                var resultreg = _reg.Register(values);


                    _reg.UpdateRecord(id,values);

                    var list = _reg.GetAllRegistration();
                    return View("View", list);
                
                //else
                //{
                //    ModelState.AddModelError("ConformPassword", "Already Exist");
                //    return View("RegisterEdit", values);
                //}

            }
            catch
            {
                return View("Error");
            }
        }

        // GET: RegistrationController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var num = _reg.FindProductByNumber(id);
                return View("RegisterDelete", num);
            }
            catch
            {
                return View("Error");
            }
        }

        // POST: RegistrationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Deletebynum(int RegistrationId)
        {
            try
            {
                _reg.DeleteRecord(RegistrationId);

                var list = _reg.GetAllRegistration();
                return View("View", list);
            }
            catch
            {
                return View("Error");
            }
        }
    }
}
