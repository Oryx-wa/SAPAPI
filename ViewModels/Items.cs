using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SupplyChain.Models
{
    public class Items
    {
        [Key]
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string CodeBars { get; set; }
    }
}