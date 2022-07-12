using System;
using System.Linq;
using System.Web.UI;
using ProCafe.Data;
using Telerik.Web.UI;

namespace ProCafe.Program.PopUps.Tanimlama
{
    public partial class Program_Tanimlamalar_Kullanici_Islemleri_PopUp : Page
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

        private int? KullaniciKey
        {
            get
            {
                if (ViewState["KullaniciKey"] == null)
                {
                    return null;
                }
                else
                {
                    return Convert.ToInt32(ViewState["KullaniciKey"]);
                }
            }
            set { ViewState["KullaniciKey"] = value; }
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

        protected void RadGridKullanici_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            RadGridKullanici.DataSource = _ProCafeDBEntities.Kullanicis.Where(p => !p.KullaniciSabit).ToList();
        }

        protected void RadGridKullanici_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                var _Kullanici = e.Item.DataItem as Kullanici;
                string kullaniciTur =
                    _ProCafeDBEntities.T_Kullanici_Tur.Single(p => p.KullaniciTurKey == _Kullanici.KullaniciTurKey)
                                      .KullaniciTurAd;
                e.Item.Cells[KullaniciTurKolon].Text = kullaniciTur;
                e.Item.Cells[ParolaKolon].Text = "******";
            }
        }

        protected void RadGridKullanici_ItemCommand(object sender, GridCommandEventArgs e)
        {
            var dataItem = e.Item as GridDataItem;
            int key = Convert.ToInt32(dataItem.GetDataKeyValue("KullaniciKey"));
            Kullanici _Kullanici = _ProCafeDBEntities.Kullanicis.Single(p => p.KullaniciKey == key);

            switch (e.CommandName)
            {
                case "Delete":
                    //şu an işlem yaptığı kullanıcıyı veya

                    //son kalan 1 kullanıcıyı silemez
                    if (RadGridKullanici.Items.Count > 1)
                    {
                        _ProCafeDBEntities.Kullanicis.Remove(_Kullanici);
                        _ProCafeDBEntities.SaveChanges();
                    }
                    else
                    {
                        RadWindowManagerTanimlama.RadAlert("Son kalan kullanıcıyı silemezsiniz.", null, 25, "Uyarı",
                                                           null);
                    }
                    break;
                case "Update":
                    KullaniciKey = key;
                    GuncelleBilgiDoldur();
                    break;
            }
        }

        protected void RadButtonKaydet_Click(object sender, EventArgs e)
        {
            var _Kullanici = new Kullanici();
            KaydetGuncelle(ref _Kullanici);
            Temizle();
            RadGridKullanici.Rebind();
        }

        protected void RadButtonTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        protected void RadButtonGüncelle_Click(object sender, EventArgs e)
        {
            Kullanici _Kullanici = _ProCafeDBEntities.Kullanicis.Single(p => p.KullaniciKey == KullaniciKey);
            KaydetGuncelle(ref _Kullanici);
            KullaniciKey = null;
            Temizle();
            ButtonGuncelleMod(false);
            RadGridKullanici.Rebind();
        }

        protected void RadButtonİptal_Click(object sender, EventArgs e)
        {
            KullaniciKey = null;
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

            RadDropDownListKullaniciTip.DataSource = _ProCafeDBEntities.T_Kullanici_Tur.ToList();
            RadDropDownListKullaniciTip.DataBind();
            RadDateInputKullaniciIseBaslamaTarihi.SelectedDate = DateTime.Now;
        }

        private void KaydetGuncelle(ref Kullanici _Kullanici)
        {
            _Kullanici.KullaniciTurKey = Convert.ToInt32(RadDropDownListKullaniciTip.SelectedValue);
            _Kullanici.KullaniciKullaniciAd = RadTextBoxKullaniciKullaniciAd.Text;
            _Kullanici.KullaniciKullaniciParola = RadTextBoxKullaniciKullaniciParola.Text;
            _Kullanici.KullaniciAd = RadTextBoxKullaniciAd.Text;
            _Kullanici.KullaniciSoyad = RadTextBoxKullaniciSoyad.Text;
            _Kullanici.KullaniciTcNo = RadNumericTextBoxKullaniciTcNo.Text;
            _Kullanici.KullaniciSgkNo = RadTextBoxKullaniciSgkNo.Text;
            _Kullanici.KullaniciIseBaslamaTarihi = RadDateInputKullaniciIseBaslamaTarihi.SelectedDate == null
                                                       ? DateTime.Now.Date
                                                       : RadDateInputKullaniciIseBaslamaTarihi.SelectedDate.Value;
            _Kullanici.KullaniciSiparisIptalYetki = CheckBoxSiparisIptalYetki.Checked;
            _Kullanici.KullaniciUcretsizSatisYetki = CheckBoxUcretsizSatisYetki.Checked;

            Kullanici_Giris_Yetki _Kullanici_Giris_Yetki;
            //yeni kullanıcı kaydet

            int key = _Kullanici.KullaniciKey;
            if (key == 0)
            {
                _ProCafeDBEntities.Kullanicis.Add(_Kullanici);

                _Kullanici_Giris_Yetki = new Kullanici_Giris_Yetki();
                KullaniciGirisBilgiOlusturDegistir(ref _Kullanici, ref _Kullanici_Giris_Yetki);
                _ProCafeDBEntities.Kullanici_Giris_Yetki.Add(_Kullanici_Giris_Yetki);
            }
            else
            {
                _Kullanici_Giris_Yetki =
                    _ProCafeDBEntities.Kullanici_Giris_Yetki.Single(p => p.KullaniciGirisYetkiKey == key);
                KullaniciGirisBilgiOlusturDegistir(ref _Kullanici, ref _Kullanici_Giris_Yetki);
            }
            //varolan kullanıcıyı güncelle

            _ProCafeDBEntities.SaveChanges();
        }

        private void KullaniciGirisBilgiOlusturDegistir(ref Kullanici _Kullanici,
                                                        ref Kullanici_Giris_Yetki _Kullanici_Giris_Yetki)
        {
            _Kullanici_Giris_Yetki.KullaniciGirisYetkiKey = _Kullanici.KullaniciKey;
            _Kullanici_Giris_Yetki.KullaniciGirisYetkiMasaSiparisYetki = CheckBoxMasaSiparisYetki.Checked;
            _Kullanici_Giris_Yetki.KullaniciGirisYetkiPaketSiparisYetki = CheckBoxPaketSiparisYetki.Checked;
            _Kullanici_Giris_Yetki.KullaniciGirisYetkiRezervasyonYetki = CheckBoxRezervasyonYetki.Checked;
            _Kullanici_Giris_Yetki.KullaniciGirisYetkiMusterilerYetki = CheckBoxMusterilerYetki.Checked;
            _Kullanici_Giris_Yetki.KullaniciGirisYetkiMutfakYetki = CheckBoxMutfakYetki.Checked;
            _Kullanici_Giris_Yetki.KullaniciGirisYetkiKasaIslemleriYetki = CheckBoxKasaIslemleriYetki.Checked;
            _Kullanici_Giris_Yetki.KullaniciGirisYetkiRaporlarYetki = CheckBoxRaporlarYetki.Checked;
            _Kullanici_Giris_Yetki.KullaniciGirisYetkiStokTakibiYetki = CheckBoxStokTakibiYetki.Checked;
            _Kullanici_Giris_Yetki.KullaniciGirisYetkiAyarlarYetki = CheckBoxAyarlarYetki.Checked;
            _Kullanici_Giris_Yetki.KullaniciGirisYetkiTanimlamalarYetki = CheckBoxTanimlamalarYetki.Checked;
            _Kullanici_Giris_Yetki.KullaniciGirisYetkiNotlarHatirlatmalarYetki =
                CheckBoxNotlarHatirlatmalarYetki.Checked;
        }

        private void GuncelleBilgiDoldur()
        {
            RadTabStripTanimlama.SelectedIndex = 0;
            RadMultiPageTanimlama.SelectedIndex = 0;

            Kullanici _Kullanici = _ProCafeDBEntities.Kullanicis.Single(p => p.KullaniciKey == KullaniciKey);

            RadDropDownListKullaniciTip.SelectedValue = _Kullanici.KullaniciTurKey.ToString();
            RadTextBoxKullaniciKullaniciAd.Text = _Kullanici.KullaniciKullaniciAd;
            RadTextBoxKullaniciKullaniciParola.Text = _Kullanici.KullaniciKullaniciParola;
            RadTextBoxKullaniciAd.Text = _Kullanici.KullaniciAd;
            RadTextBoxKullaniciSoyad.Text = _Kullanici.KullaniciSoyad;
            RadNumericTextBoxKullaniciTcNo.Text = _Kullanici.KullaniciTcNo.Trim();
            RadTextBoxKullaniciSgkNo.Text = _Kullanici.KullaniciSgkNo;
            RadDateInputKullaniciIseBaslamaTarihi.SelectedDate = _Kullanici.KullaniciIseBaslamaTarihi;
            CheckBoxSiparisIptalYetki.Checked = _Kullanici.KullaniciSiparisIptalYetki;
            CheckBoxUcretsizSatisYetki.Checked = _Kullanici.KullaniciUcretsizSatisYetki;

            Kullanici_Giris_Yetki _Kullanici_Giris_Yetki = _Kullanici.Kullanici_Giris_Yetki;
            CheckBoxMasaSiparisYetki.Checked = _Kullanici_Giris_Yetki.KullaniciGirisYetkiMasaSiparisYetki;
            CheckBoxPaketSiparisYetki.Checked = _Kullanici_Giris_Yetki.KullaniciGirisYetkiPaketSiparisYetki;
            CheckBoxRezervasyonYetki.Checked = _Kullanici_Giris_Yetki.KullaniciGirisYetkiRezervasyonYetki;
            CheckBoxMusterilerYetki.Checked = _Kullanici_Giris_Yetki.KullaniciGirisYetkiMusterilerYetki;
            CheckBoxMutfakYetki.Checked = _Kullanici_Giris_Yetki.KullaniciGirisYetkiMutfakYetki;
            CheckBoxKasaIslemleriYetki.Checked = _Kullanici_Giris_Yetki.KullaniciGirisYetkiKasaIslemleriYetki;
            CheckBoxRaporlarYetki.Checked = _Kullanici_Giris_Yetki.KullaniciGirisYetkiRaporlarYetki;
            CheckBoxStokTakibiYetki.Checked = _Kullanici_Giris_Yetki.KullaniciGirisYetkiStokTakibiYetki;
            CheckBoxAyarlarYetki.Checked = _Kullanici_Giris_Yetki.KullaniciGirisYetkiAyarlarYetki;
            CheckBoxTanimlamalarYetki.Checked = _Kullanici_Giris_Yetki.KullaniciGirisYetkiTanimlamalarYetki;
            CheckBoxNotlarHatirlatmalarYetki.Checked =
                _Kullanici_Giris_Yetki.KullaniciGirisYetkiNotlarHatirlatmalarYetki;

            ButtonGuncelleMod(true);
        }

        private void Temizle()
        {
            RadDropDownListKullaniciTip.SelectedIndex = 0;
            RadTextBoxKullaniciKullaniciAd.Text = string.Empty;
            RadTextBoxKullaniciKullaniciParola.Text = string.Empty;
            RadTextBoxKullaniciAd.Text = string.Empty;
            RadTextBoxKullaniciSoyad.Text = string.Empty;
            RadNumericTextBoxKullaniciTcNo.Text = string.Empty;
            RadTextBoxKullaniciSgkNo.Text = string.Empty;
            RadDateInputKullaniciIseBaslamaTarihi.SelectedDate = DateTime.Now;

            CheckBoxMasaSiparisYetki.Checked = false;
            CheckBoxPaketSiparisYetki.Checked = false;
            CheckBoxRezervasyonYetki.Checked = false;
            CheckBoxMusterilerYetki.Checked = false;
            CheckBoxMutfakYetki.Checked = false;
            CheckBoxKasaIslemleriYetki.Checked = false;
            CheckBoxRaporlarYetki.Checked = false;
            CheckBoxStokTakibiYetki.Checked = false;
            CheckBoxAyarlarYetki.Checked = false;
            CheckBoxTanimlamalarYetki.Checked = false;
            CheckBoxNotlarHatirlatmalarYetki.Checked = false;
            CheckBoxSiparisIptalYetki.Checked = false;
            CheckBoxUcretsizSatisYetki.Checked = false;

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