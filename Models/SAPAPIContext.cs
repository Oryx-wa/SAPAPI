using SupplyChain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SAPAPI.Models
{
    public class SAPAPIContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        //
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public SAPAPIContext() : base("name=SAPAPIContext")
        {
        }
        public DbSet<BusinessPatner> BusinessPatners { get; set; }
        public DbSet<BPLookup> BPLoookups { get; set; }
        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public DbSet<GRN> GRNs { get; set; }
        public DbSet<PurchaseRequest> PurchaseRequests { get; set; }
        public DbSet<Items> Items { get; set; }
    }
}
