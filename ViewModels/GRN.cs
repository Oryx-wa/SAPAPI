using System;
using System.Collections.Generic;

namespace SupplyChain.Models
{
    public class GRN : OIGN
    {
        public GRN()
        {
            this.LineItems = new List<IGN1>();
        }

        //public int Id { get; set; }

        public List<IGN1> LineItems { get; set; }

        //public string Status { get; set; }

        //DateTime IEntityBase<int>.CreateDate { get; set; }

        //DateTime IEntityBase<int>.UpdateDate { get; set; }

        //string IEntityBase<int>.UserSign { get; set; }
    }
}
