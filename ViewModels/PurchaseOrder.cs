using System;
using System.Collections.Generic;

namespace SupplyChain.Models
{
    public class PurchaseOrder : OPOR
    {
        public PurchaseOrder()
        {
            this.LineItems = new List<POR1>();
        }


        public List<POR1> LineItems { get; set; }

        //public int Id { get; set; }

        //public string Status { get; set; }

        //DateTime IEntityBase<int>.CreateDate { get; set; }

        //DateTime IEntityBase<int>.UpdateDate { get; set; }

        //string IEntityBase<int>.UserSign { get; set; }
    }
}
