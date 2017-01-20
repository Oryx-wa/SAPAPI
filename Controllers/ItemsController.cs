using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SAPAPI.Models;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using SupplyChain.Models;
using System;
using System.Collections.Generic;
using Autofac.Integration.WebApi;
using System.Data.Entity;

namespace SAPAPI.Controllers
{
    [AutofacControllerConfiguration]
    [Route("api/[controller]")]
    public class ItemsController : BaseController
    {
        SAPAPIContext context;
        public ItemsController(SAPAPIContext ctx)
        {
            context = ctx;
        }
        public override JsonResult Get()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public JsonResult GetForLookUp()
        {
           
            
                var items = context.Items.SqlQuery(string.Format("SELECT ItemCode,ItemName, CodeBars FROM OITM ")).ToList();

                //var settings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
                return Json(items, JsonRequestBehavior.AllowGet);
            
        }
    }
}