using SAPbobsCOM;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace SAPAPI
{
    public static class b1
    {
        private static Company oCompany = new Company();
        public static int lErrCode;
        public static string sErrMsg = "";

        public static Company B1Company
        {
            get
            {
                if (!oCompany.Connected)
                {
                    Connect();
                }
                return oCompany;
            }         
        }

        

       


        public static void Connect()
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

       
    }

    public interface IB1
    {
        Company B1Company { get;  }
       

    }
}