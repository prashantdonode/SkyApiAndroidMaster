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


        public ActionResult Index()
        {
            return View();
        }


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


    }
}