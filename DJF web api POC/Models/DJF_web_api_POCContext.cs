using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DJF_web_api_POC.Models
{
    public class DJF_web_api_POCContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public DJF_web_api_POCContext() : base("name=DJF_web_api_POCContext")
        {
        }

		public System.Data.Entity.DbSet<DJF_web_api_POC.Models.Member> Members { get; set; }

		public System.Data.Entity.DbSet<DJF_web_api_POC.Models.Association> Associations { get; set; }

		public System.Data.Entity.DbSet<DJF_web_api_POC.Models.AssociationCommittee> AssociationCommittees { get; set; }
    
    }
}
