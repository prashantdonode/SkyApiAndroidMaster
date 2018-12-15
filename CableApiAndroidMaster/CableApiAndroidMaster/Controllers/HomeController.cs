using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CableApiAndroidMaster.Models;
using CableApiAndroidMaster.Entity;

namespace CableApiAndroidMaster.Controllers
{
    public class HomeController : Controller
    {
        RegistrationApiController _objReg = new RegistrationApiController();

        CableApiAndroidMasterEntities _db = new CableApiAndroidMasterEntities();

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }


        #region Admin Registration Method

        public ActionResult AdminRegistration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminRegistration(tblAdminRegistration model)
        {
                var result = _objReg.AdminRegistration(model);

                if(result.Result.Status==1)
                {
                    return RedirectToAction("Index","Home");
                }

   
           

            return View();
        }


        #endregion


        #region LogOut Method

        public ActionResult LogOut()
        {
            return RedirectToAction("Index","Dashboard");
        }

        #endregion



        [HttpPost]
        public JsonResult GetDetails(int RegId)
        {
            var data = _db.tblAdminRegistrations.Where(psd=>psd.RegId==RegId).FirstOrDefault();

            return new JsonResult { Data=new {data=data } };
        }

      

    }
}
