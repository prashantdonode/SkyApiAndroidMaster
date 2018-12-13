namespace CableApiAndroidMaster.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using CableApiAndroidMaster.Models;

    public partial class CableApiAndroidMasterEntities : DbContext
    {
        public CableApiAndroidMasterEntities()
            : base("name=CableApiAndroidMasterEntities")
        {
        }

        public DbSet<tblAdminRegistration> tblAdminRegistrations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
