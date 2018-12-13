using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CableApiAndroidMaster.Entity;
using CableApiAndroidMaster.Models;
namespace CableApiAndroidMaster.Controllers
{
    public class DashboardController : Controller
    {
        ApprovalMasterApiController _objApproval = new ApprovalMasterApiController();
        CableApiAndroidMasterEntities _db = new CableApiAndroidMasterEntities();

    


        #region Approval Request Page Code

        public ActionResult RequestApproval()
        {
            var result = _objApproval.GetAdminApprovalRequest();

            return View(result.Result.Response);

        }

        #endregion


        #region Approval The Request Methods

        public ActionResult Approval(int id)
        {
            int Status = 0;


            if (ModelState.IsValid)
            {
                var result = _objApproval.ApprovalRequest(id);

                if (result.Result.Status == 1)
                {
                    Status = 1;
                    ViewBag.Message = Status;
                    return RedirectToAction("RequestApproval", "Dashboard");
                }


            }

            return View();
        }


        #endregion


        #region Reject The Request Methods


        public ActionResult Reject(int id)
        {
            int Status = 0;

            if (ModelState.IsValid)
            {
                var result = _objApproval.RejectRequest(id);

                if (result.Result.Status == 1)
                {
                    Status = 1;
                    ViewBag.Message = Status;
                    return RedirectToAction("RequestApproval", "Dashboard");

                }


            }

            return View();
        }


        #endregion


        #region Update Api Link Url Methods 

        public ActionResult UpdateRequest(int id)
        {
            var result = _db.tblAdminRegistrations.Find(id);
            return View(result);
        }

        [HttpPost]
        public ActionResult UpdateRequest(tblAdminRegistration model)
        {
            if(model.ApiLink!=null)
            {
                _db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                _db.SaveChanges();

                return RedirectToAction("RequestApproval", "Dashboard");
            }
          

            return View();
        }

        #endregion



    }
}