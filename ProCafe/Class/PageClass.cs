using System;
using System.Web.UI;

namespace ProCafe.Class
{
    public class PageClass
    {
        public static void MessageBox(Page _page, string _message)
        {
            string script = "<script type=\"text/javascript\">alert('" + _message + "');</script>";
            _page.ClientScript.RegisterClientScriptBlock(_page.GetType(), "alert", script);
        }

        public static DateTime ConvertDate(DateTime pTarih)
        {
            return pTarih.Date;
        }

        public static string ConvertTime(DateTime pTarih)
        {
            return pTarih.ToShortTimeString();
        }
    }
}