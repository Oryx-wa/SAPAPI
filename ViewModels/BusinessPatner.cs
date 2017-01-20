using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SupplyChain.Models
{
    public class BusinessPatner : OCRD
    {
    }

    public class BPLookup
    {
        [Key]
        public string CardCode { get; set; }
        public string CardName { get; set; }
        public string CardType { get; set; }
    }
}