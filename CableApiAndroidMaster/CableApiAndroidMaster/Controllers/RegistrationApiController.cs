using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CableApiAndroidMaster.Models;
using CableApiAndroidMaster.Entity;
using System.Threading.Tasks;
using System.Web.Http.Results;


namespace CableApiAndroidMaster.Controllers
{
    public class RegistrationApiController : ApiController
    {
        CableApiAndroidMasterEntities _db = new CableApiAndroidMasterEntities();

        #region Admin Registration

        [HttpPost]
        public async Task<ProjectResult> AdminRegistration(tblAdminRegistration model)
        {
            try
            {
                var result1 = _db.tblAdminRegistrations.Where(a => a.UserId == model.UserId && a.Password == model.Password && a.IMEINo == model.IMEINo).ToList();
                if (result1.Count != 0)
                {
                    return new ProjectResult { Message = "User Already Exist", Status = 2, Response = result1 };
                }
                else
                {
                    model.SkyStatus = 0;
                    var result = _db.tblAdminRegistrations.Max(psd => psd.RegId);
                    if (result == null)
                    {
                        result = 0;
                    }
                    model.RegId = (result.Value) + 1;

                    tblAdminRegistration _objAdmin = new tblAdminRegistration();

                    if (ModelState.IsValid)
                    {
                        _objAdmin.RegId = model.RegId;
                        _objAdmin.Name = model.Name;
                        _objAdmin.Address = model.Address;
                        _objAdmin.City = model.City;
                        _objAdmin.Email = model.Email;
                        _objAdmin.MobileNo = model.MobileNo;
                        _objAdmin.UserId = model.UserId;
                        _objAdmin.Password = model.Password;
                        _objAdmin.Pin = model.Pin;
                        _objAdmin.NoOfAgent = model.NoOfAgent;
                        //_objAdmin.RegDate = model.RegDate;
                        _objAdmin.RegDate = System.DateTime.Now.Date;
                        _objAdmin.SkyStatus = 0;
                        _objAdmin.IMEINo = model.IMEINo;

                        _db.tblAdminRegistrations.Add(_objAdmin);
                        _db.SaveChanges();


                        return new ProjectResult { Message = "Success", Status = 1, Response = _objAdmin };
                    }
                    else
                    {
                        return new ProjectResult { Message = "No data found", Status = 0, Response = null };
                    }
                }

            }
            catch (Exception ex)
            {
                return new ProjectResult { Message = ex.ToString(), Status = 0, Response = null };
            }
        }


        #endregion

        #region Admin Login

        [HttpPost]
        public async Task<ProjectResult> AdminLogin(tblAdminRegistration model)
        {
            try
            {
                if (model.Password != null)
                {
                    if (model.UserId != null)
                    {
                        var result = _db.tblAdminRegistrations.Where(a => a.UserId == model.UserId && a.Password == model.Password && a.IMEINo == model.IMEINo && a.SkyStatus==1).ToList();

                        if (result == null)
                        {
                            return new ProjectResult { Message = "Sorry User ID or Password is Wrong", Status = 0, Response = null };

                        }
                        if (result.Count != 0)
                        {
                            foreach (var item in result)
                            {
                                if (item.SkyStatus == 1)
                                {
                                    return new ProjectResult { Message = "Success", Status = 1, Response = result };

                                }
                                else
                                {
                                    return new ProjectResult { Message = "Sorry Request Not Approval", Status = 0, Response = null };

                                }
                            }

                            return new ProjectResult { Message = "Sorry Something is Wrong", Status = 0, Response = null };


                        }
                        else
                        {
                            return new ProjectResult { Message = "Sorry User ID or Password is Wrong", Status = 0, Response = null };

                        }
                    }
                    else
                    {
                        return new ProjectResult { Message = "Sorry User ID is Blank", Status = 0, Response = null };

                    }


                }
                else
                {
                    if (model.Pin != null)
                    {

                        var result = _db.tblAdminRegistrations.Where(a => a.Pin == model.Pin && a.IMEINo == model.IMEINo && a.SkyStatus==1).ToList();

                      
                        if (result.Count != 0)
                        {
                            foreach (var item in result)
                            {
                                if (item.SkyStatus == 1)
                                {
                                    return new ProjectResult { Message = "Success", Status = 1, Response = result };

                                }
                                else
                                {
                                    return new ProjectResult { Message = "Sorry Request Not Approval", Status = 0, Response = null };

                                }
                            }

                            return new ProjectResult { Message = "Sorry Something is Wrong", Status = 0, Response = null };

                        }
                        else
                        {
                            return new ProjectResult { Message = "Sorry Request Not Approval", Status = 0, Response = null };

                        }

                    }
                    else
                    {
                        return new ProjectResult { Message = "Sorry Pin is Wrong", Status = 0, Response = null };
                    }

                }


            }
            catch (Exception exp)
            {
                return new ProjectResult { Message = exp.ToString(), Status = 0, Response = null };
            }
        }

        #endregion


        #region Agent Login
        [HttpPost]
        public async Task<ProjectResult> AgentLogin(tblAdminRegistration model)
        {
            try
            {
                var result = _db.tblAdminRegistrations.Where(a => a.OperatorCode == model.OperatorCode && a.SkyStatus==1).ToList();

                if (result != null)
                {
                    return new ProjectResult { Message = "Success", Status = 1, Response = result };
                }
                else
                {
                    return new ProjectResult { Message = "Not Success", Status = 0, Response = null };
                }

            }
            catch (Exception exp)
            {
                return new ProjectResult { Message = exp.ToString(), Status = 0, Response = null };
            }

        }
        #endregion

        #region Operatorno
        [HttpPost]
        public async Task<ProjectResult> getOperatorno (tblAdminRegistration model)
        {
            try
            {
                var result = _db.tblAdminRegistrations.Where(a => a.IMEINo == model.IMEINo).ToList();

                if (result != null)
                {
                    return new ProjectResult { Message = "Success", Status = 1, Response = result };
                }
                else
                {
                    return new ProjectResult { Message = "Not Success", Status = 0, Response = null };
                }

            }
            catch (Exception exp)
            {
                return new ProjectResult { Message = exp.ToString(), Status = 0, Response = null };
            }

        }
        #endregion

        #region Agent Ip Link
        [HttpPost]
        public async Task<ProjectResult> getAgentIpLink(tblAdminRegistration model)
        {
            try
            {
                var result = _db.tblAdminRegistrations.Where(a => a.OperatorCode == model.OperatorCode).ToList();

                if (result != null)
                {
                    return new ProjectResult { Message = "Success", Status = 1, Response = result };
                }
                else
                {
                    return new ProjectResult { Message = "Not Success", Status = 0, Response = null };
                }

            }
            catch (Exception exp)
            {
                return new ProjectResult { Message = exp.ToString(), Status = 0, Response = null };
            }

        }
        #endregion

        //    [HttpPost]
        //    public JsonResult AdminRegistrationjson(tblAdminRegistration model)
        //    {
        //        try
        //        {
        //            var result1 = _db.tblAdminRegistrations.Where(a => a.UserId == model.UserId && a.Password == model.Password && a.IMEINo == model.IMEINo).ToList();
        //            if (result1.Count != 0)
        //            {
        //                return new JsonResult { Data = new { result = result1} };
        //            }
        //            else
        //            {
        //                model.SkyStatus = 0;
        //                var result = _db.tblAdminRegistrations.Max(psd => psd.RegId);
        //                if (result == null)
        //                {
        //                    result = 0;
        //                }
        //                model.RegId = (result.Value) + 1;

        //                tblAdminRegistration _objAdmin = new tblAdminRegistration();

        //                if (ModelState.IsValid)
        //                {
        //                    _objAdmin.RegId = model.RegId;
        //                    _objAdmin.Name = model.Name;
        //                    _objAdmin.Address = model.Address;
        //                    _objAdmin.City = model.City;
        //                    _objAdmin.Email = model.Email;
        //                    _objAdmin.MobileNo = model.MobileNo;
        //                    _objAdmin.UserId = model.UserId;
        //                    _objAdmin.Password = model.Password;
        //                    _objAdmin.Pin = model.Pin;
        //                    _objAdmin.NoOfAgent = model.NoOfAgent;
        //                    //_objAdmin.RegDate = model.RegDate;
        //                    _objAdmin.RegDate = System.DateTime.Now.Date;
        //                    _objAdmin.SkyStatus = 0;
        //                    _objAdmin.IMEINo = model.IMEINo;

        //                    _db.tblAdminRegistrations.Add(_objAdmin);
        //                    _db.SaveChanges();


        //                    return new JsonResult { Data = new { result = "Success" } };
        //                }
        //                else
        //                {
        //                    return new JsonResult { Data = new { result = "Failed" } };
        //                }
        //            }

        //        }
        //        catch (Exception ex)
        //        {
        //            return new JsonResult { Data = new { result = ex.ToString() } };
        //        }
        //    }

    }
}
