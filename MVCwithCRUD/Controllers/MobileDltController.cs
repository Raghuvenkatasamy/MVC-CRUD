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
    public class MobileDltController : Controller
    {
        private readonly IMobileDetailsRepository _mDtl;
        private readonly string _configuration;
        public MobileDltController(IMobileDetailsRepository mdtl, IConfiguration configuration)
        {
            _mDtl = mdtl;
            _configuration = configuration.GetConnectionString("DbConnection");
        }
        // GET: MobileDetailsController1
        public ActionResult Index()
        {
            var list=_mDtl.ReadMVC();
            return View("List", list);
        }

        // GET: MobileDetailsController1/Details/5
        public ActionResult Details(int id)
        {
            var num = _mDtl.ReadbynumberSP(id);
            return View("Details",num);
        }

        // GET: MobileDetailsController1/Create
        public ActionResult Create()
        {
            return View("Create",new MobileDetail());
        }

        // POST: MobileDetailsController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MobileDetail values)
        {
            try
            {
                if (values.DateofMaufacture < DateTime.Today)
                {
                    ModelState.AddModelError("DateofMaufacture", "DOM should be less than today");
                    return View("Create",values);
                }
                if (ModelState.IsValid) {
                    _mDtl.InsertMVC(values);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View("Create",values);
                }
               
            }
            catch
            {
                return View();
            }
        }

        // GET: MobileDetailsController1/Edit/5
        public ActionResult Edit(int id)
        {
            var num = _mDtl.ReadbynumberSP(id);
            return View("Edit",num);
        }

        // POST: MobileDetailsController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,MobileDetail values)
        {
            try
            {
                if (values.DateofMaufacture < DateTime.Today)
                {
                    ModelState.AddModelError("DateofMaufacture", "DOM should be less than today");
                    return View("Edit", values);
                }
                if (ModelState.IsValid)
                {
                    _mDtl.UpdateMVC(id, values);
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View("Edit", values);
                }
                
            }
            catch
            {
                return View();
            }
        }

        // GET: MobileDetailsController1/Delete/5
        public ActionResult Delete(int id)
        {
           var num= _mDtl.ReadbynumberSP(id);
            return View("Delete",num);
        }

        // POST: MobileDetailsController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Deletebynum(int MobileId)
        {
            try
            {
                _mDtl.DeleteRecordMVC(MobileId);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
