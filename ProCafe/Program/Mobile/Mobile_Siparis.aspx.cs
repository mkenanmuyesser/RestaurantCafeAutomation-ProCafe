using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProCafe.Class;
using ProCafe.Data;
using Telerik.Web.UI;

namespace ProCafe.Program.Mobile
{
    public partial class Mobile_Siparis : Page
    {
        #region [PRIVATE MEMBERS] ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private readonly ProCafeDBEntities _ProCafeDBEntities = new ProCafeDBEntities();

        private int BirimFiyatKolon = 5;
        private int UrunKolon = 4;

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

        public bool MasaDurum
        {
            get
            {
                string masadurum = Request.QueryString["MasaDurum"];
                switch (masadurum)
                {
                    case "A":
                        return true;
                        break;
                    case "K":
                        return false;
                        break;
                    default:
                        return false;
                        break;
                }
            }
        }

        public int MasaKey
        {
            get { return Convert.ToInt32(Request.QueryString["MasaKey"]); }
        }

        public int SiparisKey
        {
            get { return Convert.ToInt32(Request.QueryString["SiparisKey"]); }
        }

        private List<A_Siparis_Urun> KapaliUrunler
        {
            get { return Session["KapaliUrunler"] as List<A_Siparis_Urun>; }
            set { Session["KapaliUrunler"] = value; }
        }

        private struct PageControl
        {
            public const string LinkButtonKategori = "LinkButtonKategori";
            public const string RadBinaryImageKategori = "RadBinaryImageKategori";
            public const string LinkButtonUrun = "LinkButtonUrun";
            public const string RadBinaryImageUrun = "RadBinaryImageUrun";
            public const string LabelUrunAd = "LabelUrunAd";
            public const string LabelUrunFiyat = "LabelUrunFiyat";
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

        protected void RepeaterKategori_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var _T_Urun_Kategori_Tur = e.Item.DataItem as T_Urun_Kategori_Tur;

            var linkButtonKategori = e.Item.FindControl(PageControl.LinkButtonKategori) as RadButton;
            linkButtonKategori.CommandArgument = _T_Urun_Kategori_Tur.UrunKategoriTurKey.ToString();
            var radBinaryImageKategori =
                (linkButtonKategori.FindControl(PageControl.RadBinaryImageKategori) as RadBinaryImage);
            radBinaryImageKategori.DataValue = _T_Urun_Kategori_Tur.UrunKategoriResim;
            radBinaryImageKategori.ToolTip = _T_Urun_Kategori_Tur.UrunKategoriTurAd;
        }

        protected void DataListUrun_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            var _Urun = e.Item.DataItem as Urun;

            var _LabelUrunAd = e.Item.FindControl(PageControl.LabelUrunAd) as Label;
            _LabelUrunAd.Text = _Urun.UrunAd;

            var linkButtonUrun = e.Item.FindControl(PageControl.LinkButtonUrun) as LinkButton;
            linkButtonUrun.CommandArgument = _Urun.UrunKey.ToString();

            var radBinaryImageUrun = e.Item.FindControl(PageControl.RadBinaryImageUrun) as RadBinaryImage;
            radBinaryImageUrun.ToolTip = _Urun.UrunAd;

            var _LabelUrunFiyat = e.Item.FindControl(PageControl.LabelUrunFiyat) as Label;
            _LabelUrunFiyat.Text = String.Format("{0:#.00}", _Urun.UrunFiyat);
        }

        protected void RadGridSiparisUrun_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            RadGridSiparisUrun.DataSource =
                _ProCafeDBEntities.A_Siparis_Urun.Where(p => p.SiparisKey == SiparisKey).ToList();
        }

        protected void RadGridSiparisUrun_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridHeaderItem)
            {
                ViewState["ToplamFiyat"] = 0m;
            }
            else if (e.Item is GridDataItem)
            {
                var _A_Siparis_Urun = e.Item.DataItem as A_Siparis_Urun;

                if (_A_Siparis_Urun.SiparisOnay)
                {
                    e.Item.ForeColor = Color.Red;
                }

                e.Item.Cells[UrunKolon].Text = _A_Siparis_Urun.Urun.UrunAd;
                e.Item.Cells[BirimFiyatKolon].Text = String.Format("{0:#.00}", _A_Siparis_Urun.Urun.UrunFiyat);

                decimal toplamfiyat = _A_Siparis_Urun.Urun.UrunFiyat;
                ViewState["ToplamFiyat"] = Convert.ToDecimal(ViewState["ToplamFiyat"]) + toplamfiyat;
            }

            string toplam = ViewState["ToplamFiyat"].ToString();

            RadNumericTextBoxGenelToplam.Value = Convert.ToDouble(toplam);
            LabelToplam.Text = toplam;
        }

        protected void RadGridSiparisUrun_ItemCommand(object sender, GridCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "Select":
                    ButtonAktifPasif(true);
                    break;
                case "Deselect":
                    ButtonAktifPasif(false);
                    foreach (GridDataItem satir in RadGridSiparisUrun.Items)
                    {
                        satir.Selected = false;
                    }
                    break;
            }
        }

        protected void LinkButtonKategori_Click(object sender, EventArgs e)
        {
            var _LinkButton = sender as RadButton;
            int _kategoriKey = Convert.ToInt32(_LinkButton.CommandArgument);
            UrunLoad(_kategoriKey);
        }

        protected void LinkButtonUrun_Click(object sender, EventArgs e)
        {
            var _LinkButton = sender as LinkButton;
            int urunkey = Convert.ToInt32(_LinkButton.CommandArgument);
            SipariseUrunEkle(urunkey);
        }

        protected void RadButtonUrunEkle_Click(object sender, EventArgs e)
        {
            int _UrunKey = Convert.ToInt32(RadGridSiparisUrun.SelectedValue);
            SipariseUrunEkle(_UrunKey);
        }

        protected void RadButtonUrunEksilt_Click(object sender, EventArgs e)
        {
            int index = RadGridSiparisUrun.SelectedItems[0].ItemIndex;
            int siparisurunkey = Convert.ToInt32(RadGridSiparisUrun.Items[index].GetDataKeyValue("SiparisUrunKey"));
            A_Siparis_Urun _A_Siparis_Urun =
                _ProCafeDBEntities.A_Siparis_Urun.Single(p => p.SiparisUrunKey == siparisurunkey);
            if (!_A_Siparis_Urun.SiparisOnay || GirisYapanKullanici.KullaniciSiparisIptalYetki)
            {
                SipariseUrunEksilt(_A_Siparis_Urun);
            }
        }

        protected void RadButtonYenile_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void RadButtonMasa_Click(object sender, EventArgs e)
        {
            //siparişe bağlı ürünleri kilitle
            IQueryable<A_Siparis_Urun> SiparisUrunDizi =
                _ProCafeDBEntities.A_Siparis_Urun.Where(p => p.SiparisKey == SiparisKey);
            foreach (A_Siparis_Urun SiparisUrun in SiparisUrunDizi)
            {
                SiparisUrun.SiparisOnay = true;
            }

            Sipari _Sipari = _ProCafeDBEntities.Siparis.Single(p => p.SiparisKey == SiparisKey);
            _Sipari.SiparisMutfakOnayTarih = null;
            _Sipari.MutfakOnayKullaniciKey = null;

            _ProCafeDBEntities.SaveChanges();

            Response.Redirect("Mobile_Masa.aspx");
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


            Sipari _Sipari = _ProCafeDBEntities.Siparis.Single(p => p.SiparisKey == SiparisKey);

            KapaliUrunler = _Sipari.A_Siparis_Urun.ToList();

            LabelSiparisAcilisZamani.Text = _Sipari.SiparisAlindiTarih.ToString();


            Masa _Masa = _ProCafeDBEntities.Masas.Single(p => p.MasaKey == MasaKey);
            LabelMasaNo.Text = _Masa.MasaNo;

            LabelSiparisiKimAldi.Text = GirisYapanKullanici.KullaniciAd + " " +
                                        GirisYapanKullanici.KullaniciSoyad;

            KategoriLoad();

            int ilkkategori =
                _ProCafeDBEntities.T_Urun_Kategori_Tur.OrderBy(p => p.UrunKategoriTurSiralama)
                                  .First()
                                  .UrunKategoriTurKey;
            UrunLoad(ilkkategori);

            for (int i = 1; i < 10; i++)
            {
                RadComboBoxUrunSayisi.Items.Add(new RadComboBoxItem(i.ToString(), i.ToString()));
            }
        }

        private void KategoriLoad()
        {
            var kategoriler = new List<T_Urun_Kategori_Tur>();
            var tumtur = new T_Urun_Kategori_Tur
                {
                    UrunKategoriTurAd = "Tümü",
                    UrunKategoriTurSiralama = 0,
                };
            kategoriler.Add(tumtur);
            kategoriler.AddRange(_ProCafeDBEntities.T_Urun_Kategori_Tur.OrderBy(p => p.UrunKategoriTurSiralama).ToList());
            RepeaterKategori.DataSource = kategoriler;
            RepeaterKategori.DataBind();
        }

        private void UrunLoad(int pKategoriKey)
        {
            if (pKategoriKey == 0)
            {
                DataListUrun.DataSource =
                    _ProCafeDBEntities.Uruns.Where(p => p.UrunAktif).OrderBy(p => p.UrunSiralama).ToList();
            }
            else
            {
                DataListUrun.DataSource =
                    _ProCafeDBEntities.Uruns.Where(p => p.UrunAktif && p.UrunKategoriTurKey == pKategoriKey)
                                      .OrderBy(p => p.UrunSiralama)
                                      .ToList();
            }
            DataListUrun.DataBind();
        }

        private void SipariseUrunEkle(int pUrunKey)
        {
            Urun eklenenurun = _ProCafeDBEntities.Uruns.Single(p => p.UrunKey == pUrunKey);

            Sipari _Sipari = _ProCafeDBEntities.Siparis.Single(p => p.SiparisKey == SiparisKey);

            int eklenecekurunsayisi = Convert.ToInt32(RadComboBoxUrunSayisi.SelectedValue);
            for (int i = 0; i < eklenecekurunsayisi; i++)
            {

                A_Siparis_Urun _A_Siparis_Urun;

                _A_Siparis_Urun = new A_Siparis_Urun
                    {
                        SiparisKey = SiparisKey,
                        UrunKey = pUrunKey,
                        //SiparisUrunKey = 
                        Urun = eklenenurun,
                        Sipari = _Sipari,
                    };
                _ProCafeDBEntities.A_Siparis_Urun.Add(_A_Siparis_Urun);

                _A_Siparis_Urun.Sipari.SiparisToplam += eklenenurun.UrunFiyat;
            }

            _ProCafeDBEntities.SaveChanges();

            RadComboBoxUrunSayisi.SelectedIndex = 0;

            RadGridSiparisUrun.Rebind();

            foreach (GridDataItem item in RadGridSiparisUrun.MasterTableView.Items)
            {
                if (item.GetDataKeyValue("UrunKey").ToString() == pUrunKey.ToString())
                {
                    item.Selected = true;
                }
            }

            ButtonAktifPasif(true);
        }

        private void SipariseUrunEksilt(A_Siparis_Urun _A_Siparis_Urun)
        {
            //siparis kaç adet var

            _A_Siparis_Urun.Sipari.SiparisToplam -= _A_Siparis_Urun.Urun.UrunFiyat;

            _ProCafeDBEntities.A_Siparis_Urun.Remove(_A_Siparis_Urun);

            _ProCafeDBEntities.SaveChanges();

            RadGridSiparisUrun.Rebind();

            ButtonAktifPasif(false);

            RadComboBoxUrunSayisi.SelectedIndex = 0;
        }

        private void ButtonAktifPasif(bool durum)
        {
            if (durum)
            {
                RadButtonUrunArttir.Enabled = true;
                RadButtonUrunEksilt.Enabled = true;
            }
            else
            {
                RadButtonUrunArttir.Enabled = false;
                RadButtonUrunEksilt.Enabled = false;
            }
        }

        #endregion

        #region [PUBLIC METHODS] ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        #endregion
    }
}