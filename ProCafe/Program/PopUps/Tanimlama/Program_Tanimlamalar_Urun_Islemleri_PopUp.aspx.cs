using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using ProCafe.Data;
using Telerik.Web.UI;

namespace ProCafe.Program.PopUps.Tanimlama
{
    public partial class Program_Tanimlamalar_Urun_Islemleri_PopUp : Page
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

        private int? UrunKey
        {
            get
            {
                if (ViewState["UrunKey"] == null)
                {
                    return null;
                }
                else
                {
                    return Convert.ToInt32(ViewState["UrunKey"]);
                }
            }
            set { ViewState["UrunKey"] = value; }
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

        protected void RadGridUrun_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            RadGridUrun.DataSource =
                _ProCafeDBEntities.Uruns.OrderBy(
                    p => new { p.T_Urun_Kategori_Tur.UrunKategoriTurSiralama, p.UrunSiralama }).ToList();
        }

        protected void RadGridUrun_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                var _Urun = e.Item.DataItem as Urun;
            }
        }

        protected void RadGridUrun_ItemCommand(object sender, GridCommandEventArgs e)
        {
            var dataItem = e.Item as GridDataItem;
            int key = Convert.ToInt32(dataItem.GetDataKeyValue("UrunKey"));
            Urun _Urun = _ProCafeDBEntities.Uruns.Single(p => p.UrunKey == key);

            switch (e.CommandName)
            {
                case "Delete":
                    //son kalan 1 ürünü silemez
                    if (RadGridUrun.Items.Count > 1)
                    {
                        _ProCafeDBEntities.Uruns.Remove(_Urun);
                        _ProCafeDBEntities.SaveChanges();
                    }
                    else
                    {
                        RadWindowManagerTanimlama.RadAlert("Son kalan ürünü silemezsiniz.", null, 25, "Uyarı", null);
                    }
                    break;
                case "Update":
                    UrunKey = key;
                    GuncelleBilgiDoldur();
                    break;
            }
        }

        protected void RadButtonKaydet_Click(object sender, EventArgs e)
        {
            var _Urun = new Urun();
            KaydetGuncelle(ref _Urun);
            Temizle();
            RadGridUrun.Rebind();
        }

        protected void RadButtonTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        protected void RadButtonGüncelle_Click(object sender, EventArgs e)
        {
            Urun _Urun = _ProCafeDBEntities.Uruns.Single(p => p.UrunKey == UrunKey);
            KaydetGuncelle(ref _Urun);
            UrunKey = null;
            Temizle();
            ButtonGuncelleMod(false);
            RadGridUrun.Rebind();
        }

        protected void RadButtonİptal_Click(object sender, EventArgs e)
        {
            UrunKey = null;
            Temizle();
            ButtonGuncelleMod(false);
        }

        #endregion

        #region [PRIVATE METHODS] ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private void SetInitialValues()
        {
            if (GirisYapanKullanici == null)
            {
                Response.Redirect("../../../Default.aspx");
                return;
            }

            List<T_Kullanici_Tur> kullanicitipleri = _ProCafeDBEntities.T_Kullanici_Tur.ToList();
            kullanicitipleri.Insert(0, new T_Kullanici_Tur { KullaniciTurKey = 0, KullaniciTurAd = "Hiçbiri" });
            RadDropDownListKullaniciTip.DataSource = kullanicitipleri;
            RadDropDownListKullaniciTip.DataBind();

            RadDropDownListUrunKategoriTip.DataSource = _ProCafeDBEntities.T_Urun_Kategori_Tur.ToList();
            RadDropDownListUrunKategoriTip.DataBind();
            CheckBoxUrunAktif.Checked = true;
        }

        private void KaydetGuncelle(ref Urun _Urun)
        {
            _Urun.UrunKategoriTurKey = Convert.ToInt32(RadDropDownListUrunKategoriTip.SelectedValue);
            _Urun.UrunAktif = CheckBoxUrunAktif.Checked;
            _Urun.UrunAd = RadTextBoxUrunAd.Text;
            _Urun.UrunFiyat =
                Convert.ToDecimal(RadTextBoxUrunFiyat.Text == "" ? "0" : RadTextBoxUrunFiyat.Text.Replace('.', ','));
            _Urun.UrunSiralama =
                Convert.ToInt32(RadNumericTextBoxUrunSiralama.Text == "" ? "0" : RadNumericTextBoxUrunSiralama.Text);
            int _kullanicitipid = Convert.ToInt32(RadDropDownListKullaniciTip.SelectedValue);
            _Urun.KullaniciTurKey = _kullanicitipid == 0 ? null : (int?)_kullanicitipid;
            _Urun.UrunAciklama = RadTextBoxUrunAciklama.Text;


            //yeni ürünü kaydet
            if (_Urun.UrunKey == 0)
            {
                _ProCafeDBEntities.Uruns.Add(_Urun);
            }
            //varolan ürünü güncelle

            _ProCafeDBEntities.SaveChanges();
        }

        private void GuncelleBilgiDoldur()
        {
            RadTabStripTanimlama.SelectedIndex = 0;
            RadMultiPageTanimlama.SelectedIndex = 0;

            Urun _Urun = _ProCafeDBEntities.Uruns.Single(p => p.UrunKey == UrunKey);

            RadDropDownListUrunKategoriTip.SelectedValue = _Urun.UrunKategoriTurKey.ToString();
            CheckBoxUrunAktif.Checked = _Urun.UrunAktif;
            RadTextBoxUrunAd.Text = _Urun.UrunAd;
            RadTextBoxUrunFiyat.Value = Convert.ToDouble(_Urun.UrunFiyat);
            RadNumericTextBoxUrunSiralama.Value = Convert.ToInt32(_Urun.UrunSiralama);
            RadDropDownListKullaniciTip.SelectedValue = _Urun.KullaniciTurKey.ToString();
            RadTextBoxUrunAciklama.Text = _Urun.UrunAciklama;

            ButtonGuncelleMod(true);
        }

        private void Temizle()
        {
            RadDropDownListUrunKategoriTip.SelectedIndex = 0;
            CheckBoxUrunAktif.Checked = true;
            RadTextBoxUrunAd.Text = string.Empty;
            RadTextBoxUrunFiyat.Value = 0;
            RadNumericTextBoxUrunSiralama.Value = 0;
            RadDropDownListKullaniciTip.SelectedIndex = 0;
            RadTextBoxUrunAciklama.Text = string.Empty;

            RadTabStripTanimlama.SelectedIndex = 0;
            RadMultiPageTanimlama.SelectedIndex = 0;
        }

        private void ButtonGuncelleMod(bool pGuncelle)
        {
            if (pGuncelle)
            {
                RadButtonKaydet.Visible = false;
                RadButtonTemizle.Visible = false;
                RadButtonGüncelle.Visible = true;
                RadButtonİptal.Visible = true;
            }
            else
            {
                RadButtonKaydet.Visible = true;
                RadButtonTemizle.Visible = true;
                RadButtonGüncelle.Visible = false;
                RadButtonİptal.Visible = false;
            }
        }

        #endregion

        #region [PUBLIC METHODS] ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        #endregion
    }
}