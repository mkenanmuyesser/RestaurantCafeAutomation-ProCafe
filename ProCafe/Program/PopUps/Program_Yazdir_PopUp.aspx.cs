using ProCafe.Data;
using ProCafe.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Reporting;

namespace ProCafe.Program.PopUps
{
    public partial class Program_Yazdir_PopUp : System.Web.UI.Page
    {
        #region [PRIVATE MEMBERS] ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        ProCafeDBEntities _ProCafeDBEntities = new ProCafeDBEntities();

        private Kullanici GirisYapanKullanici
        {
            get
            {
                if (Session["User"] == null)
                {
                    return null;
                }
                else
                {
                    var _Kullanici = Session["User"] as Kullanici;
                    Session["User"] = _Kullanici;
                    return _Kullanici;
                }
            }
        }

        public int SiparisKey
        {
            get
            {
                string key = Request.QueryString["Key"];
                if (string.IsNullOrEmpty(key))
                {
                    return 0;
                }
                else
                {
                    int keyint;
                    int.TryParse(key, out keyint);
                    return keyint;
                }
            }
        }

        #endregion

        #region [PAGE] ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetInitialValues();
            }
        }

        #endregion

        #region [PAGE CONTROL EVENTS] ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        protected void RadButtonCikis_Click(object sender, EventArgs e)
        {

            //siparişe bağlı ürünleri teslim edildi göster
            IQueryable<A_Siparis_Urun> SiparisUrunDizi =
                _ProCafeDBEntities.A_Siparis_Urun.Where(p => p.SiparisKey == SiparisKey);
            foreach (A_Siparis_Urun SiparisUrun in SiparisUrunDizi)
            {
                SiparisUrun.SiparisMutfakTeslim = true;
                SiparisUrun.Sipari.SiparisMutfakOnayTarih = DateTime.Now;
                SiparisUrun.Sipari.MutfakOnayKullaniciKey = GirisYapanKullanici.KullaniciKey;
            }

            _ProCafeDBEntities.SaveChanges();

            string script = "<script language='javascript' type='text/javascript'>CloseOnReload()</script>";
            Page.ClientScript.RegisterStartupScript(GetType(), "CloseOnReload1", script);
        }

        #endregion

        #region [PRIVATE METHODS] ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private void SetInitialValues()
        {
            if (GirisYapanKullanici == null)
            {
                Response.Redirect("../../Default.aspx");
                return;
            }

            var instanceReportSource = new InstanceReportSource();
            string tip = Request.QueryString["T"];
            switch (tip)
            {
                case "F":
                    var _Report_Fis = new Report_Fis();
                    _Report_Fis.ReportParameters["SiparisKey"].Value = SiparisKey;
                    instanceReportSource.ReportDocument = _Report_Fis;
                    break;
                case "M":
                    var _Report_Mutfak_Fis = new Report_Mutfak_Fis();
                    _Report_Mutfak_Fis.ReportParameters["SiparisKey"].Value = SiparisKey;
                    instanceReportSource.ReportDocument = _Report_Mutfak_Fis;
                    break;
                default:
                    break;
            }


            ReportViewerRapor.ReportSource = instanceReportSource;
        }

        #endregion

        #region [PUBLIC METHODS] ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        #endregion
    }
}