using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProCafe.Class;
using ProCafe.Data;
using Telerik.Web.UI;

namespace ProCafe.Program
{
    public partial class Program_Raporlar : Page
    {
        #region [PRIVATE MEMBERS] ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private ProCafeDBEntities _ProCafeDBEntities = new ProCafeDBEntities();

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
            public const string ImageButtonRapor = "ImageButtonRapor";
            public const string LabelRaporBaslik = "LabelRaporBaslik";
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

        protected void DataListRapor_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            var _MenuClass = e.Item.DataItem as MenuClass;

            var imageButtonRapor = e.Item.FindControl(PageControl.ImageButtonRapor) as ImageButton;
            imageButtonRapor.ImageUrl = _MenuClass.Resim;
            imageButtonRapor.ToolTip = _MenuClass.Aciklama;
            imageButtonRapor.Attributes.Add("Rapor", _MenuClass.Link);

            var labelBaslik = e.Item.FindControl(PageControl.LabelRaporBaslik) as Label;
            labelBaslik.Text = _MenuClass.Baslik;
        }

        protected void ImageButtonRapor_Click(object sender, ImageClickEventArgs e)
        {
            var _ImageButton = sender as ImageButton;
            string raporLink = _ImageButton.Attributes["Rapor"];

            var _RadWindowManager = Page.Master.FindControl(PageControl.RadWindowManagerProgram) as RadWindowManager;
            _RadWindowManager.Windows.Clear();

            var _RadWindow = new RadWindow
                {
                    Modal = true,
                    DestroyOnClose = true,
                    VisibleOnPageLoad = true,
                    EnableShadow = false,
                    Width = 980,
                    Height = 550,
                    RenderMode = RenderMode.Lightweight,
                    Behaviors = WindowBehaviors.Close,
                    NavigateUrl = "PopUps/Program_Raporlar_PopUp.aspx?Rapor=" + raporLink,
                };
            _RadWindowManager.Windows.Add(_RadWindow);
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

            RaporLoad();
        }

        private void RaporLoad()
        {
            var raporlar = new List<MenuClass>();
            string resimyolu = @"../Image/MenuImages/";
            var menu1 = new MenuClass
                {
                    Aciklama = "Adisyonlar",
                    Baslik = "Adisyonlar",
                    Resim = resimyolu + "bar-chart_128x128.png",
                    Link = "Adisyon",
                };
            var menu2 = new MenuClass
                {
                    Aciklama = "Gün Sonu Raporu",
                    Baslik = "Gün Sonu Raporu",
                    Resim = resimyolu + "bar-chart_128x128.png",
                    Link = "GunSonuRaporu",
                };
            var menu3 = new MenuClass
                {
                    Aciklama = "Satış Oranları (Aylık)",
                    Baslik = "Satış Oranları (Aylık)",
                    Resim = resimyolu + "bar-chart_128x128.png",
                    Link = "SatisOranAylik",
                };
            var menu4 = new MenuClass
                {
                    Aciklama = "Satış Oranları (Ürün)",
                    Baslik = "Satış Oranları (Ürün)",
                    Resim = resimyolu + "bar-chart_128x128.png",
                    Link = "SatisOranUrun",
                };
            var menu5 = new MenuClass
                {
                    Aciklama = "Satış Oranları (Mutfak)",
                    Baslik = "Satış Oranları (Mutfak)",
                    Resim = resimyolu + "bar-chart_128x128.png",
                    Link = "SatisOranMutfak",
                };
            var menu6 = new MenuClass
                {
                    Aciklama = "Satış Oranları (Garson)",
                    Baslik = "Satış Oranları (Garson)",
                    Resim = resimyolu + "bar-chart_128x128.png",
                    Link = "SatisOranGarson",
                };

            raporlar.Add(menu1);
            raporlar.Add(menu2);
            raporlar.Add(menu3);
            raporlar.Add(menu4);
            raporlar.Add(menu5);
            raporlar.Add(menu6);

            DataListRapor.DataSource = raporlar;
            DataListRapor.DataBind();
        }

        #endregion

        #region [PUBLIC METHODS] ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        #endregion
    }
}