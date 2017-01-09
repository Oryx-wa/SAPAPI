using SAPbobsCOM;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Web.Http;

namespace SAPAPI.Controllers
{
    public abstract  class BaseController : System.Web.Http.ApiController
    {
        protected Company oCompany = new Company();
        protected int lErrCode;
        protected string sErrMsg = "";

        [HttpGet]
        public abstract System.Web.Mvc.JsonResult Get();

        public void Connect()
        {
            try
            {
                oCompany.Server = ConfigurationManager.AppSettings["LicenseServer"];
                oCompany.CompanyDB = ConfigurationManager.AppSettings["CompanyDB"];
                oCompany.DbServerType = BoDataServerTypes.dst_MSSQL2008;

                //db user name
                oCompany.DbUserName = ConfigurationManager.AppSettings["DBUserName"];
                oCompany.DbPassword = ConfigurationManager.AppSettings["DBPassword"];
                //user name
                oCompany.UserName = ConfigurationManager.AppSettings["SAPUserName"];
                //user password
                oCompany.Password = ConfigurationManager.AppSettings["SAPPassword"];
                oCompany.language = SAPbobsCOM.BoSuppLangs.ln_English;

                // Use Windows authentication for database server.
                // True for NT server authentication,
                // False for database server authentication.
                oCompany.UseTrusted = false;

                //insert license server and port
                oCompany.LicenseServer = ConfigurationManager.AppSettings["LicenseServer"].ToString().Trim() + ":30000";

                //Connecting to a company DB
                int lRetCode = oCompany.Connect();

                if (lRetCode != 0)
                {
                    oCompany.GetLastError(out lErrCode, out sErrMsg);
                    oCompany.Disconnect();
                    return;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        protected virtual System.Web.Mvc.JsonResult Json(object data, string contentType,
           Encoding contentEncoding, System.Web.Mvc.JsonRequestBehavior behavior)
        {
            return new System.Web.Mvc.JsonResult()
            {
                Data = data,
                ContentType = contentType,
                ContentEncoding = contentEncoding,
                JsonRequestBehavior = behavior,
                MaxJsonLength = int.MaxValue
            };
        }

        protected virtual System.Web.Mvc.JsonResult Json(object data, System.Web.Mvc.JsonRequestBehavior behavior)
        {
            return new System.Web.Mvc.JsonResult()
            {
                Data = data,
                JsonRequestBehavior = behavior,
                MaxJsonLength = int.MaxValue
            };
        }
    }
}
