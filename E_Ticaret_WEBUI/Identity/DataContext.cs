using E_Ticaret_Entity.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace E_Ticaret_WEBUI.Identity
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DataContext() : base("MSSQL")
        {
        }

    }
}