using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProCafe.Class;
using ProCafe.Data;
using Telerik.Web.UI;

namespace ProCafe.Program
{
    public partial class Program_Tanimlamalar : Page
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
            public const string ImageButtonResim = "ImageButtonResim";
            public const string LabelBaslik = "LabelBaslik";
            public const string LabelUrl = "LabelUrl";
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

        protected void DataListTanimlar_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            var _MenuClass = e.Item.DataItem as MenuClass;

            var _LabelBaslik = e.Item.FindControl(PageControl.LabelBaslik) as Label;
            _LabelBaslik.Text = _MenuClass.Baslik;

            var _LabelUrl = e.Item.FindControl(PageControl.LabelUrl) as Label;
            _LabelUrl.Text = _MenuClass.Link;

            var imageButtonResim = e.Item.FindControl(PageControl.ImageButtonResim) as ImageButton;
            imageButtonResim.ImageUrl = _MenuClass.Resim;
            imageButtonResim.ToolTip = _MenuClass.Aciklama;
            imageButtonResim.Enabled = _MenuClass.Aktif;
        }

        protected void ImageButtonResim_Click(object sender, ImageClickEventArgs e)
        {
            var _ImageButton = sender as ImageButton;

            var _LabelUrl = _ImageButton.FindControl(PageControl.LabelUrl) as Label;
            string link = _LabelUrl.Text;

            var _RadWindowManager = Master.FindControl(PageControl.RadWindowManagerProgram) as RadWindowManager;
            _RadWindowManager.Windows.Clear();

            var _RadWindow = new RadWindow
                {
                    Modal = true,
                    DestroyOnClose = true,
                    VisibleOnPageLoad = true,
                    EnableShadow = false,
                    Width = 970,
                    Height = 550,
                    RenderMode = RenderMode.Lightweight,
                    Behaviors = WindowBehaviors.Close,
                    NavigateUrl = "PopUps/Tanimlama/" + link,
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

            MenuLoad();
        }

        private void MenuLoad()
        {
            var menuler = new List<MenuClass>();
            string resimyolu = @"../Image/MenuImages/";
            var menu1 = new MenuClass
                {
                    Aciklama = "Kullanıcı İşlemleri",
                    Baslik = "Kullanıcı İşlemleri",
                    Resim = resimyolu + "admin_128x128.png",
                    Link = "Program_Tanimlamalar_Kullanici_Islemleri_PopUp.aspx",
                    Aktif = true,
                };
            var menu2 = new MenuClass
                {
                    Aciklama = "Masa Kat/Bölge İşlemleri",
                    Baslik = "Masa Kat/Bölge İşlemleri",
                    Resim = resimyolu + "maps_128x128.png",
                    Link = "Program_Tanimlamalar_Masa_Kat_Bolge_Islemleri_PopUp.aspx",
                    Aktif = true,
                };
            var menu3 = new MenuClass
                {
                    Aciklama = "Masa İşlemleri",
                    Baslik = "Masa İşlemleri",
                    Resim = resimyolu + "flow-chart_128x128.png",
                    Link = "Program_Tanimlamalar_Masa_Islemleri_PopUp.aspx",
                    Aktif = true,
                };
            var menu4 = new MenuClass
                {
                    Aciklama = "Ürün Kategori İşlemleri",
                    Baslik = "Ürün Kategori İşlemleri",
                    Resim = resimyolu + "shipping_128x128.png",
                    Link = "Program_Tanimlamalar_Urun_Kategori_Islemleri_PopUp.aspx",
                    Aktif = true,
                };
            var menu5 = new MenuClass
                {
                    Aciklama = "Ürün Opsiyon İşlemleri",
                    Baslik = "Ürün Opsiyon İşlemleri",
                    Resim = resimyolu + "sale_128x128.png",
                    Link = "Program_Tanimlamalar_Urun_Opsiyon_Islemleri_PopUp.aspx",
                    Aktif = false,
                };
            var menu6 = new MenuClass
                {
                    Aciklama = "Ürün İşlemleri",
                    Baslik = "Ürün İşlemleri",
                    Resim = resimyolu + "bar-code_128x128.png",
                    Link = "Program_Tanimlamalar_Urun_Islemleri_PopUp.aspx",
                    Aktif = true,
                };

            menuler.Add(menu1);
            menuler.Add(menu2);
            menuler.Add(menu3);
            menuler.Add(menu4);
            menuler.Add(menu5);
            menuler.Add(menu6);

            DataListTanimlar.DataSource = menuler;
            DataListTanimlar.DataBind();
        }

        #endregion

        #region [PUBLIC METHODS] ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        #endregion
    }
}