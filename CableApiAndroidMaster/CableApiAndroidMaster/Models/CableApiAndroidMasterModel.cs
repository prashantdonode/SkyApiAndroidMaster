using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CableApiAndroidMaster.Models
{
    public class CableApiAndroidMasterModel
    {
    }

    public partial class tblAdminRegistration
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Aid { get; set; }
        public Nullable<int> RegId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string MobileNo { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public string Pin { get; set; }
        public Nullable<System.DateTime> RegDate { get; set; }
        public Nullable<int> NoOfAgent { get; set; }
        public int SkyStatus { get; set; }
        public string OperatorCode { get; set; }
        public string IMEINo { get; set; }
        public string ApiLink { get; set; }
    }

    public class ProjectResult
    {
        public string Message { get; set; }
        public int Status { get; set; }
        public object Response { get; set; }
    }

    public class tblValidatePinModel
    {
        public string Pin { get; set; }
    }


}