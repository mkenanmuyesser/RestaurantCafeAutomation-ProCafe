using System;
using System.Web.UI;
using ProCafe.Data;
using ProCafe.Report;
using Telerik.Reporting;
using Telerik.Reporting.Processing;
using System.Threading;

namespace ProCafe.Program.PopUps
{
    public partial class Program_Raporlar_PopUp : Page
    {
        #region [PRIVATE MEMBERS] ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

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
                    return _Kullanici;
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

        protected void RadButtonAra_Click(object sender, EventArgs e)
        {
            SetInitialValues();
            ReportViewerRapor.RefreshData();
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

            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("tr-TR");
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("tr-TR");  

            if (!IsPostBack)
            {
                RadDateTimePickerBaslangic.SelectedDate = DateTime.Now.Date;
                RadDateTimePickerBitis.SelectedDate = DateTime.Now.Date.AddDays(1);
            }

            PanelParametre.Visible = false;
            var instanceReportSource = new InstanceReportSource();

            string rapor = Request.QueryString["Rapor"];
            switch (rapor)
            {
                case "Adisyon":
                    PanelParametre.Visible = true;
                    var _Report_Adisyon = new Report_Adisyon();
                    _Report_Adisyon.ReportParameters["BaslangicTarih"].Value = RadDateTimePickerBaslangic.SelectedDate.Value;
                    _Report_Adisyon.ReportParameters["BitisTarih"].Value = RadDateTimePickerBitis.SelectedDate.Value;
                    instanceReportSource.ReportDocument = _Report_Adisyon;
                    break;
                case "GunSonuRaporu":
                    PanelParametre.Visible = true;
                    var _Report_Gun_Sonu_Raporu = new Report_Gun_Sonu_Raporu();
                    _Report_Gun_Sonu_Raporu.ReportParameters["BaslangicTarih"].Value = RadDateTimePickerBaslangic.SelectedDate.Value;
                    _Report_Gun_Sonu_Raporu.ReportParameters["BitisTarih"].Value = RadDateTimePickerBitis.SelectedDate.Value;
                    instanceReportSource.ReportDocument = _Report_Gun_Sonu_Raporu;
                    break;
                case "SatisOranGarson":
                    instanceReportSource.ReportDocument = new Report_Satis_Oran_Garson();
                    break;
                case "SatisOranUrun":
                    instanceReportSource.ReportDocument = new Report_Satis_Oran_Urun();
                    break;
                case "SatisOranAylik":
                    var _Report_Satis_Oran_Aylik = new Report_Satis_Oran_Aylik();
                    _Report_Satis_Oran_Aylik.ReportParameters["Yil"].Value = DateTime.Now.Year;
                    instanceReportSource.ReportDocument = _Report_Satis_Oran_Aylik;
                    break;
                case "SatisOranMutfak":
                    instanceReportSource.ReportDocument = new Report_Satis_Oran_Mutfak();
                    break;
                default:
                    return;
            }
            ReportViewerRapor.ReportSource = instanceReportSource;            
        }

        #endregion

        #region [PUBLIC METHODS] ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        #endregion
    }
}