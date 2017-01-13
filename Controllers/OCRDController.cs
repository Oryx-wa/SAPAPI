﻿using Newtonsoft.Json;
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
        public JsonResult GetForLookUp()
        {
            using (var context = new SAPAPIContext())
            {
                var ocrds = context.BusinessPatners.SqlQuery("SELECT CardCode,CardName FROM OCRD where ").ToList();

                var settings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
                return Json(ocrds, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult GetForLookUp(string searchString)
        {
            using (var context = new SAPAPIContext())
            {
                var ocrds = context.BusinessPatners.SqlQuery(string.Format("SELECT CardCode,CardName FROM OCRD where CardCode = '{0}' or CardName = '{0}' or CardType = '{0}'", searchString)).ToList();

                var settings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
                return Json(ocrds, JsonRequestBehavior.AllowGet);
            }
        }

    }
}