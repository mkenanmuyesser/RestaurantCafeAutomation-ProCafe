using System;
using System.Web.UI;
using ProCafe.Data;
using Telerik.Web.UI;

namespace ProCafe.Program
{
    public partial class Program_Masa_Siparis : Page
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

        private struct PageControl
        {
            public const string RadWindowManagerProgram = "RadWindowManagerProgram";
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

        protected void RadButtonHesapAktar_Click(object sender, EventArgs e)
        {
            var _RadWindowManager = Page.Master.FindControl(PageControl.RadWindowManagerProgram) as RadWindowManager;
            _RadWindowManager.Windows.Clear();

            var _RadWindow = new RadWindow
            {
                ID = "Program_Masa_Aktarma_PopUp",
                Modal = true,
                DestroyOnClose = true,
                VisibleOnPageLoad = true,
                EnableShadow = false,
                Width = 480,
                Height = 550,
                RenderMode = RenderMode.Lightweight,
                NavigateUrl =
                    "PopUps/Program_Masa_Aktarma_PopUp.aspx"
            };
            _RadWindowManager.Windows.Add(_RadWindow);
        }

        protected void RadButtonYenile_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        #endregion

        #region [PRIVATE METHODS] ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private void SetInitialValues()
        {
            if (GirisYapanKullanici == null)
            {
                Response.Redirect("../Default.aspx");
                return;
            }
        }

        #endregion

        #region [PUBLIC METHODS] ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        #endregion
    }
}