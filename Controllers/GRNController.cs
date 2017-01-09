using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SAPAPI.Models;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using SupplyChain.Models;
using System;
using System.Collections.Generic;
using SAPbobsCOM;

namespace SAPAPI.Controllers
{
    [Route("api/[controller]")]
    public class GRNController : BaseController
    {
        //[HttpPost ValidateModelState]
        [Route("Get")]
        public override JsonResult  Get()
        {
            using (var context = new SAPAPIContext())
            {
                var ocrds = context.GRNs.SqlQuery("SELECT * FROM OIGN").ToList();

                var settings = new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() };
                return Json(ocrds, JsonRequestBehavior.DenyGet);
            }
        }


        //[HttpPost ValidateModelState]
        [HttpPost]
        [Route("Add")]
        public JsonResult Add([System.Web.Http.FromBody]GRN grnModel)
        {
            Connect();
            try
            {
                int oGRNLineCount = grnModel.LineItems.Count;

                Documents documents = (Documents)oCompany.GetBusinessObject(BoObjectTypes.oPurchaseDeliveryNotes);
                documents.CardCode = grnModel.CardCode;
                documents.HandWritten = SAPbobsCOM.BoYesNoEnum.tNO;
                documents.DocDate = grnModel.DocDate;
                documents.DocDueDate = grnModel.DocDueDate;

                if (oGRNLineCount > 0)
                {
                    foreach (IGN1 row1 in grnModel.LineItems)
                    {
                        documents.Lines.ItemCode = row1.ItemCode;
                        //documents.Lines.ItemDescription = row1.des;
                        documents.Lines.Price = row1.Price;
                        documents.Lines.ShipDate = DateTime.Today;
                        documents.Lines.Quantity = row1.Quantity;
                        documents.Lines.Add();
                    }
                }
                int resp = documents.Add();

                if (resp != 0)
                {
                    return Json(new Error() { ErrorCode = oCompany.GetLastErrorCode().ToString(), Description = oCompany.GetLastErrorDescription() }, JsonRequestBehavior.AllowGet);
                }
                return Json(new string[] { "GRN Added Successfully!" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                oCompany.Disconnect();
                return Json(new Error() { ErrorCode = ex.Source, Description = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [Route("Edit")]
        public void Edit(int id, [System.Web.Http.FromBody]GRN prModel)
        {
            Connect();

        }

    }
}