using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProCafe.Class;
using ProCafe.Data;

namespace ProCafe.Program
{
    public partial class Program_Main : Page
    {
        #region [PRIVATE MEMBERS] ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private readonly ProCafeDBEntities _ProCafeDBEntities = new ProCafeDBEntities();

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
            public const string LabelBaslik = "LabelBaslik";
            public const string ImageButtonResim = "ImageButtonResim";
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

        protected void DataListMenu_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            var menuClass = e.Item.DataItem as MenuClass;

            var labelBaslik = e.Item.FindControl(PageControl.LabelBaslik) as Label;
            labelBaslik.Text = menuClass.Baslik;

            var imageButtonResim = e.Item.FindControl(PageControl.ImageButtonResim) as ImageButton;
            imageButtonResim.ImageUrl = menuClass.Resim;
            imageButtonResim.ToolTip = menuClass.Aciklama;
            imageButtonResim.PostBackUrl = menuClass.Link;
            imageButtonResim.Enabled = menuClass.Aktif;
        }

        protected void ImageButtonResim_Click(object sender, ImageClickEventArgs e)
        {
            var _ImageButtonResim = sender as ImageButton;

            if (_ImageButtonResim.ToolTip == "Çıkış")
            {
                Session["User"] = null;
                Response.Redirect("../Default.aspx", true);
            }
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

            Kullanici_Giris_Yetki _Kullanici_Giris_Yetki = GirisYapanKullanici.Kullanici_Giris_Yetki;

            var menu1 = new MenuClass
                {
                    Aciklama = "Masa Sipariş",
                    Baslik = "Masa Sipariş",
                    Resim = resimyolu + "shopping_128x128.png",
                    Link = "Program_Masa_Siparis.aspx",
                    Aktif = _Kullanici_Giris_Yetki.KullaniciGirisYetkiMasaSiparisYetki,
                };
            var menu2 = new MenuClass
                {
                    Aciklama = "Paket Sipariş",
                    Baslik = "Paket Sipariş",
                    Resim = resimyolu + "packaging_128x128.png",
                    Link = "Program_Paket_Siparis.aspx",
                    Aktif = _Kullanici_Giris_Yetki.KullaniciGirisYetkiPaketSiparisYetki,
                };
            var menu3 = new MenuClass
                {
                    Aciklama = "Rezervasyon",
                    Baslik = "Rezervasyon",
                    Resim = resimyolu + "calendar_128x128.png",
                    Link = "Program_Rezervasyon.aspx",
                    Aktif = _Kullanici_Giris_Yetki.KullaniciGirisYetkiRezervasyonYetki,
                };
            var menu4 = new MenuClass
                {
                    Aciklama = "Müşteriler",
                    Baslik = "Müşteriler",
                    Resim = resimyolu + "user_128x128.png",
                    Link = "Program_Musteriler.aspx",
                    Aktif = _Kullanici_Giris_Yetki.KullaniciGirisYetkiMusterilerYetki,
                };
            var menu5 = new MenuClass
                {
                    Aciklama = "Mutfak",
                    Baslik = "Mutfak",
                    Resim = resimyolu + "store_128x128.png",
                    Link = "Program_Mutfak.aspx",
                    Aktif = _Kullanici_Giris_Yetki.KullaniciGirisYetkiMutfakYetki,
                };
            var menu6 = new MenuClass
                {
                    Aciklama = "Kasa İşlemleri",
                    Baslik = "Kasa İşlemleri",
                    Resim = resimyolu + "money_128x128.png",
                    Link = "Program_Kasa_Islemleri.aspx",
                    Aktif = _Kullanici_Giris_Yetki.KullaniciGirisYetkiKasaIslemleriYetki,
                };
            var menu7 = new MenuClass
                {
                    Aciklama = "Raporlar",
                    Baslik = "Raporlar",
                    Resim = resimyolu + "pie-chart_128x128.png",
                    Link = "Program_Raporlar.aspx",
                    Aktif = _Kullanici_Giris_Yetki.KullaniciGirisYetkiRaporlarYetki,
                };
            var menu8 = new MenuClass
                {
                    Aciklama = "Stok Takibi",
                    Baslik = "Stok Takibi",
                    Resim = resimyolu + "bar-code_128x128.png",
                    Link = "Program_Stok_Takibi.aspx",
                    Aktif = _Kullanici_Giris_Yetki.KullaniciGirisYetkiStokTakibiYetki,
                };
            var menu9 = new MenuClass
                {
                    Aciklama = "Ayarlar",
                    Baslik = "Ayarlar",
                    Resim = resimyolu + "security_128x128.png",
                    Link = "Program_Ayarlar.aspx",
                    Aktif = _Kullanici_Giris_Yetki.KullaniciGirisYetkiAyarlarYetki,
                };
            var menu10 = new MenuClass
                {
                    Aciklama = "Tanımlamalar",
                    Baslik = "Tanımlamalar",
                    Resim = resimyolu + "edit_128x128.png",
                    Link = "Program_Tanimlamalar.aspx",
                    Aktif = _Kullanici_Giris_Yetki.KullaniciGirisYetkiTanimlamalarYetki,
                };

            var menu11 = new MenuClass
                {
                    Aciklama = "Notlar Hatırlatmalar",
                    Baslik = "Notlar</br>Hatırlatmalar",
                    Resim = resimyolu + "alert_128x128.png",
                    Link = "Program_Notlar_Hatirlatmalar.aspx",
                    Aktif = _Kullanici_Giris_Yetki.KullaniciGirisYetkiNotlarHatirlatmalarYetki,
                };
            var menu12 = new MenuClass
                {
                    Aciklama = "Çıkış",
                    Baslik = "Çıkış",
                    Resim = resimyolu + "delete.png",
                    Link = "",
                    Aktif = true,
                };

            menuler.Add(menu1);
            menuler.Add(menu2);
            menuler.Add(menu3);
            menuler.Add(menu4);
            menuler.Add(menu5);
            menuler.Add(menu6);
            menuler.Add(menu7);
            menuler.Add(menu8);
            menuler.Add(menu9);
            menuler.Add(menu10);
            menuler.Add(menu11);
            menuler.Add(menu12);

            DataListMenu.DataSource = menuler;
            DataListMenu.DataBind();
        }

        #endregion

        #region [PUBLIC METHODS] ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        #endregion
    }
}