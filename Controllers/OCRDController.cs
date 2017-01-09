using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SAPAPI.Models;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using SupplyChain.Models;
using System;
using System.Collections.Generic;

namespace SAPAPI.Controllers
{
    [Route("api/[controller]")]
    public class OCRDController : BaseController
    {
        public override JsonResult  Get()
        {
            using (var context = new SAPAPIContext())
            {
                var ocrds = context.BusinessPatners.SqlQuery("SELECT * FROM OCRD").ToList();

                var settings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
                return Json(ocrds, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetForLookUp(string CardCode)
        {
            using (var context = new SAPAPIContext())
            {
                var ocrds = context.BusinessPatners.SqlQuery(string.Format("SELECT * FROM OCRD where CardCode = '{0}' ", CardCode)).ToList();

                var settings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
                return Json(ocrds, JsonRequestBehavior.AllowGet);
            }
        }

    }
}