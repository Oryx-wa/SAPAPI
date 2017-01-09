using System;
using System.Collections.Generic;

namespace SupplyChain.Models
{
    public class PurchaseRequest : OPRQ
    {
        public PurchaseRequest()
        {
            this.LineItems = new List<PRQ1>();
        }

        public List<PRQ1> LineItems { get; set; }

        //public int Id { get; set; }

        //public string Status { get; set; }

        //DateTime IEntityBase<int>.CreateDate { get; set; }

        //DateTime IEntityBase<int>.UpdateDate { get; set; }

        //string IEntityBase<int>.UserSign { get; set; }
    }
}
