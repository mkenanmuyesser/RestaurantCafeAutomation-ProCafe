using System;
using System.Linq;
using System.Web.UI;
using ProCafe.Data;
using Telerik.Web.UI;

namespace ProCafe.Program.PopUps.Tanimlama
{
    public partial class Program_Tanimlamalar_Masa_Islemleri_PopUp : Page
    {
        #region [PRIVATE MEMBERS] ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private readonly ProCafeDBEntities _ProCafeDBEntities = new ProCafeDBEntities();

        private int KullaniciTurKolon = 4, ParolaKolon = 6;

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

        private int? MasaKey
        {
            get
            {
                if (ViewState["MasaKey"] == null)
                {
                    return null;
                }
                else
                {
                    return Convert.ToInt32(ViewState["MasaKey"]);
                }
            }
            set { ViewState["MasaKey"] = value; }
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

        protected void RadGridMasa_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            RadGridMasa.DataSource = _ProCafeDBEntities.Masas.ToList();
        }

        protected void RadGridMasa_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                var _Masa = e.Item.DataItem as Masa;
                //string kullaniciTur =_ProCafeDBEntities.T_Kullanici_Tur.Single(p => p.KullaniciTurKey == _Kullanici.KullaniciTurKey).KullaniciTurAd;
                //e.Item.Cells[KullaniciTurKolon].Text = kullaniciTur;
                //e.Item.Cells[ParolaKolon].Text = "******";
            }
        }

        protected void RadGridMasa_ItemCommand(object sender, GridCommandEventArgs e)
        {
            var dataItem = e.Item as GridDataItem;
            int key = Convert.ToInt32(dataItem.GetDataKeyValue("MasaKey"));
            Masa _Masa = _ProCafeDBEntities.Masas.Single(p => p.MasaKey == key);

            switch (e.CommandName)
            {
                case "Delete":
                    //şu an işlem yaptığı kullanıcıyı veya

                    //son kalan 1 kullanıcıyı silemez
                    if (RadGridMasa.Items.Count > 1)
                    {
                        _ProCafeDBEntities.Masas.Remove(_Masa);
                        _ProCafeDBEntities.SaveChanges();
                    }
                    else
                    {
                        RadWindowManagerTanimlama.RadAlert("Son kalan masayı silemezsiniz.", null, 25, "Uyarı", null);
                    }
                    break;
                case "Update":
                    MasaKey = key;
                    GuncelleBilgiDoldur();
                    break;
            }
        }

        protected void RadButtonKaydet_Click(object sender, EventArgs e)
        {
            var _Masa = new Masa();
            KaydetGuncelle(ref _Masa);
            Temizle();
            RadGridMasa.Rebind();
        }

        protected void RadButtonTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        protected void RadButtonGüncelle_Click(object sender, EventArgs e)
        {
            Masa _Kullanici = _ProCafeDBEntities.Masas.Single(p => p.MasaKey == MasaKey);
            KaydetGuncelle(ref _Kullanici);
            MasaKey = null;
            Temizle();
            ButtonGuncelleMod(false);
            RadGridMasa.Rebind();
        }

        protected void RadButtonİptal_Click(object sender, EventArgs e)
        {
            MasaKey = null;
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

            RadDropDownListKatBolgeTip.DataSource = _ProCafeDBEntities.T_Masa_Kat_Bolge_Tur.ToList();
            RadDropDownListKatBolgeTip.DataBind();
            CheckBoxMasaAktif.Checked = true;
        }

        private void KaydetGuncelle(ref Masa _Masa)
        {
            _Masa.MasaKatBolgeKey = Convert.ToInt32(RadDropDownListKatBolgeTip.SelectedValue);
            _Masa.MasaAktif = CheckBoxMasaAktif.Checked;
            _Masa.MasaNo = RadTextBoxMasaNo.Text;
            _Masa.MasaKisi = RadNumericTextBoxMasaKisi.Text == "" ? 1 : Convert.ToInt32(RadNumericTextBoxMasaKisi.Text);
            _Masa.MasaSira = RadNumericTextBoxMasaSiraNo.Text == "" ? (byte)0 : Convert.ToByte(RadNumericTextBoxMasaSiraNo.Text);
            _Masa.MasaAciklama = RadTextBoxMasaAciklama.Text;

            //yeni masa kaydet
            if (_Masa.MasaKey == 0)
            {
                _ProCafeDBEntities.Masas.Add(_Masa);
            }
            //varolan masa güncelle

            _ProCafeDBEntities.SaveChanges();
        }

        private void GuncelleBilgiDoldur()
        {
            RadTabStripTanimlama.SelectedIndex = 0;
            RadMultiPageTanimlama.SelectedIndex = 0;

            Masa _Masa = _ProCafeDBEntities.Masas.Single(p => p.MasaKey == MasaKey);

            RadDropDownListKatBolgeTip.SelectedValue = _Masa.MasaKatBolgeKey.ToString();
            CheckBoxMasaAktif.Checked = _Masa.MasaAktif;
            RadTextBoxMasaNo.Text = _Masa.MasaNo;
            RadNumericTextBoxMasaKisi.Text = _Masa.MasaKisi.ToString();
            RadNumericTextBoxMasaSiraNo.Text = _Masa.MasaSira.ToString();
            RadTextBoxMasaAciklama.Text = _Masa.MasaAciklama;

            ButtonGuncelleMod(true);
        }

        private void Temizle()
        {
            RadDropDownListKatBolgeTip.SelectedIndex = 0;
            CheckBoxMasaAktif.Checked = true;
            RadTextBoxMasaNo.Text = string.Empty;
            RadNumericTextBoxMasaKisi.Text = string.Empty;
            RadNumericTextBoxMasaSiraNo.Text = string.Empty;
            RadTextBoxMasaAciklama.Text = string.Empty;

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