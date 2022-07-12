using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web.UI.WebControls;
using ProCafe.Class;
using ProCafe.Data;
using Telerik.Web.UI;

namespace ProCafe.UserControl
{
    public partial class Kasa_Mutfak_User_Control : System.Web.UI.UserControl
    {
        #region [PRIVATE MEMBERS] ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private readonly ProCafeDBEntities _ProCafeDBEntities = new ProCafeDBEntities();

        private int DurumKolon = 6;
        private int MasaKolon = 7;
        private int OdenenKolon = 9;
        private int ToplamKolon = 8;
        private int TurKolon = 5;

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

        private string SayfaTip
        {
            get { return ViewState["SayfaTip"].ToString(); }
            set { ViewState["SayfaTip"] = value; }
        }

        private struct PageControl
        {
            public const string RepeaterUrunler = "RepeaterUrunler";
            public const string RadWindowManagerProgram = "RadWindowManagerProgram";
            public const string LabelSiparis = "LabelSiparis";
            public const string LabelSiparisSor = "LabelSiparisSor";
        }

        #endregion

        #region [PAGE] ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        protected void Page_Load(object sender, EventArgs e)
        {
            RadWindowManagerProgram.Windows.Clear();

            if (!IsPostBack)
            {
                SetInitialValues();
            }
        }

        #endregion

        #region [PAGE CONTROL EVENTS] ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        protected void RadGridHesaplar_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            List<Sipari> _SipariDizi;
            switch (SayfaTip)
            {
                case "M":
                    if (RadDateTimePickerBaslangicTarih.SelectedDate == null ||
                        RadDateTimePickerBitisTarih.SelectedDate == null)
                    {
                        switch (RadioButtonListMutfakSunum.SelectedIndex)
                        {
                            case 0:
                            default:
                                _SipariDizi =
                                    _ProCafeDBEntities.Siparis.Where(p => p.SiparisHesapKapatildiTarih == null)
                                                      .OrderByDescending(p => p.SiparisKey)
                                                      .ToList();
                                break;
                            case 1:
                                _SipariDizi =
                                    _ProCafeDBEntities.Siparis.Where(
                                        p => p.SiparisMutfakOnayTarih == null && p.SiparisHesapKapatildiTarih == null)
                                                      .OrderByDescending(p => p.SiparisKey).ToList();
                                break;
                            case 2:
                                _SipariDizi =
                                    _ProCafeDBEntities.Siparis.Where(
                                        p => p.SiparisMutfakOnayTarih != null && p.SiparisHesapKapatildiTarih == null)
                                                      .OrderByDescending(p => p.SiparisKey).ToList();
                                break;
                        }
                    }
                    else
                    {
                        DateTime baslangic = RadDateTimePickerBaslangicTarih.SelectedDate.Value;
                        DateTime bitis = RadDateTimePickerBitisTarih.SelectedDate.Value;

                        switch (RadioButtonListMutfakSunum.SelectedIndex)
                        {
                            case 0:
                            default:
                                _SipariDizi =
                                    _ProCafeDBEntities.Siparis.Where(
                                        p =>
                                        p.SiparisHesapKapatildiTarih == null && p.SiparisAlindiTarih >= baslangic &&
                                        p.SiparisAlindiTarih < bitis).OrderByDescending(p => p.SiparisKey).ToList();
                                break;
                            case 1:
                                _SipariDizi =
                                    _ProCafeDBEntities.Siparis.Where(
                                        p =>
                                        p.SiparisMutfakOnayTarih == null && p.SiparisHesapKapatildiTarih == null &&
                                        p.SiparisAlindiTarih >= baslangic && p.SiparisAlindiTarih < bitis)
                                                      .OrderByDescending(p => p.SiparisKey)
                                                      .ToList();
                                break;
                            case 2:
                                _SipariDizi =
                                    _ProCafeDBEntities.Siparis.Where(
                                        p =>
                                        p.SiparisMutfakOnayTarih != null && p.SiparisHesapKapatildiTarih == null &&
                                        p.SiparisAlindiTarih >= baslangic && p.SiparisAlindiTarih < bitis)
                                                      .OrderByDescending(p => p.SiparisKey)
                                                      .ToList();
                                break;
                        }
                    }
                    break;
                case "K":
                    if (RadDateTimePickerBaslangicTarih.SelectedDate == null ||
                        RadDateTimePickerBitisTarih.SelectedDate == null)
                    {
                        switch (RadioButtonListOdenmeler.SelectedIndex)
                        {
                            case 0:
                            default:
                                _SipariDizi = _ProCafeDBEntities.Siparis.OrderByDescending(p => p.SiparisKey).ToList();
                                break;
                            case 1:
                                _SipariDizi =
                                    _ProCafeDBEntities.Siparis.Where(p => p.SiparisHesapKapatildiTarih != null)
                                                      .OrderByDescending(p => p.SiparisKey)
                                                      .ToList();
                                break;
                            case 2:
                                _SipariDizi =
                                    _ProCafeDBEntities.Siparis.Where(p => p.SiparisHesapKapatildiTarih == null)
                                                      .OrderByDescending(p => p.SiparisKey)
                                                      .ToList();
                                break;
                            case 3:
                                _SipariDizi =
                                    _ProCafeDBEntities.Siparis.Where(p => p.SiparisIptal)
                                                      .OrderByDescending(p => p.SiparisKey)
                                                      .ToList();
                                break;
                            case 4:
                                _SipariDizi =
                                    _ProCafeDBEntities.Siparis.Where(p => p.SiparisUcretsizKapatma)
                                                      .OrderByDescending(p => p.SiparisKey)
                                                      .ToList();
                                break;
                            case 5:
                                _SipariDizi =
                                    _ProCafeDBEntities.Siparis.Where(p => p.SiparisParcali)
                                                      .OrderByDescending(p => p.SiparisKey)
                                                      .ToList();
                                break;
                        }
                    }
                    else
                    {
                        DateTime baslangic = RadDateTimePickerBaslangicTarih.SelectedDate.Value;
                        DateTime bitis = RadDateTimePickerBitisTarih.SelectedDate.Value;

                        switch (RadioButtonListOdenmeler.SelectedIndex)
                        {
                            case 0:
                            default:
                                _SipariDizi =
                                    _ProCafeDBEntities.Siparis.Where(
                                        p => p.SiparisAlindiTarih >= baslangic && p.SiparisAlindiTarih < bitis)
                                                      .OrderByDescending(p => p.SiparisKey)
                                                      .ToList();
                                break;
                            case 1:
                                _SipariDizi =
                                    _ProCafeDBEntities.Siparis.Where(
                                        p =>
                                        p.SiparisHesapKapatildiTarih != null && p.SiparisAlindiTarih >= baslangic &&
                                        p.SiparisAlindiTarih < bitis).OrderByDescending(p => p.SiparisKey).ToList();
                                break;
                            case 2:
                                _SipariDizi =
                                    _ProCafeDBEntities.Siparis.Where(
                                        p =>
                                        p.SiparisHesapKapatildiTarih == null && p.SiparisAlindiTarih >= baslangic &&
                                        p.SiparisAlindiTarih < bitis).OrderByDescending(p => p.SiparisKey).ToList();
                                break;
                            case 3:
                                _SipariDizi =
                                    _ProCafeDBEntities.Siparis.Where(
                                        p =>
                                        p.SiparisIptal && p.SiparisAlindiTarih >= baslangic &&
                                        p.SiparisAlindiTarih < bitis).OrderByDescending(p => p.SiparisKey).ToList();
                                break;
                            case 4:
                                _SipariDizi =
                                    _ProCafeDBEntities.Siparis.Where(
                                        p =>
                                        p.SiparisUcretsizKapatma && p.SiparisAlindiTarih >= baslangic &&
                                        p.SiparisAlindiTarih < bitis).OrderByDescending(p => p.SiparisKey).ToList();
                                break;
                            case 5:
                                _SipariDizi =
                                    _ProCafeDBEntities.Siparis.Where(
                                        p =>
                                        p.SiparisParcali && p.SiparisAlindiTarih >= baslangic &&
                                        p.SiparisAlindiTarih < bitis).OrderByDescending(p => p.SiparisKey).ToList();
                                break;
                        }
                    }
                    break;
                default:
                    _SipariDizi = _ProCafeDBEntities.Siparis.OrderByDescending(p => p.SiparisKey).ToList();
                    break;
            }

            RadGridHesaplar.DataSource = _SipariDizi;
        }

        protected void RadGridHesaplar_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                var _Sipari = e.Item.DataItem as Sipari;
                List<A_Siparis_Urun> _A_Siparis_Urunler = _Sipari.A_Siparis_Urun.ToList();

                var _RepeaterUrunler = e.Item.FindControl(PageControl.RepeaterUrunler) as Repeater;
                _RepeaterUrunler.DataSource = _A_Siparis_Urunler;
                _RepeaterUrunler.DataBind();

                e.Item.Cells[TurKolon].Text = _Sipari.MasaKey == null ? "Paket" : "Masa";
                e.Item.Cells[MasaKolon].Text = _Sipari.MasaKey == null ? "" : _Sipari.Masa.MasaNo;

                string durum = "";
                Genel_Ayar _GenelAyar = _ProCafeDBEntities.Genel_Ayar.Single();

                if (_Sipari.SiparisIptal)
                {
                    durum = "İptal";
                }
                else if (_Sipari.SiparisUcretsizKapatma)
                {
                    durum = "Ücretsiz";
                }
                else if (_Sipari.SiparisHesapKapatildiTarih == null)
                {
                    if (_GenelAyar.GenelMutfakKullanimi)
                    {
                        if (_Sipari.MasaKey == null)
                        {
                            //paket servis ise
                            durum = _Sipari.SiparisMutfakOnayTarih == null ? "Mutfakta" : "Teslimde";
                        }
                        else
                        {
                            //masa siparis ise
                            durum = _Sipari.SiparisMutfakOnayTarih == null ? "Mutfakta" : "Sunumda";
                        }
                    }
                    else
                    {
                        if (_Sipari.MasaKey == null)
                        {
                            //paket servis ise
                            durum = "Teslimde";
                        }
                        else
                        {
                            //masa siparis ise
                            durum = "Sunumda";
                        }
                    }
                }
                else
                {
                    durum = _Sipari.MasaKey == null ? "Teslim edildi</br>Hesap kapatıldı" : "Hesap kapatıldı";
                }

                e.Item.Cells[DurumKolon].Text = durum;
            }
        }

        protected void RadGridHesaplar_ItemCommand(object sender, GridCommandEventArgs e)
        {
            var _GridDataItem = e.Item as GridDataItem;
            int _SiparisKey = Convert.ToInt32(_GridDataItem.GetDataKeyValue("SiparisKey"));
            switch (e.CommandName)
            {
                case "Select":
                    Sipari _Sipari = _ProCafeDBEntities.Siparis.Single(p => p.SiparisKey == _SiparisKey);
                    if (_Sipari.SiparisHesapKapatildiTarih == null)
                    {
                        ButtonAktifPasif(true);
                    }
                    else
                    {
                        ButtonAktifPasif(false);
                    }

                    decimal indirimoran = _ProCafeDBEntities.Genel_Ayar.Single().GenelIndirimOran;

                    decimal toplam =
                        _Sipari.A_Siparis_Urun.Where(p => !p.SiparisParca).Sum(p => p.Urun.UrunFiyat);

                    LabelToplam.Text = toplam.ToString();
                    LabelIndirimliToplam.Text = ((toplam * indirimoran) / 100m).ToString();
                    RadTextBoxGenelToplam.Value = Convert.ToDouble(toplam);

                    //eğer sunumda ise ve mutfak ise teslim butonunu kapat
                    string durum = _GridDataItem.Cells[DurumKolon].Text;
                    if (SayfaTip == "M" && durum == "Sunumda")
                    {
                        RadButtonMutfakTeslim.Enabled = false;
                    }

                    if (SayfaTip == "K" && _Sipari.SiparisParcali)
                    {
                        RadButtonTamaminiOdeme.Enabled = false;
                        RadButtonIndirimliOdeme.Enabled = false;
                    }

                    break;
                case "Deselect":
                    ButtonAktifPasif(false);
                    foreach (GridDataItem satir in RadGridHesaplar.Items)
                    {
                        satir.Selected = false;
                    }

                    LabelToplam.Text = "0";
                    LabelIndirimliToplam.Text = "0";
                    RadTextBoxGenelToplam.Value = 0;
                    break;
            }
        }

        protected void RepeaterUrunler_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Repeater rpt = sender as Repeater;
            var _A_Siparis_Urun = e.Item.DataItem as A_Siparis_Urun;
            string urunad = _A_Siparis_Urun.Urun.UrunAd;
            var _LabelSiparis = e.Item.FindControl(PageControl.LabelSiparis) as Label;
            switch (SayfaTip)
            {
                case "M":
                    _LabelSiparis.Text = urunad + "</br>";

                    if (!_A_Siparis_Urun.SiparisMutfakTeslim)
                    {
                        _LabelSiparis.Font.Underline = true;
                        _LabelSiparis.Font.Bold = true;
                        _LabelSiparis.ForeColor = Color.Red;
                    }
                    else
                    {
                        _LabelSiparis.Font.Italic = true;
                    }
                    break;
                case "K":
                    int sayac = 1;
                    foreach (RepeaterItem item in rpt.Items)
                    {
                        Label lbl = item.FindControl(PageControl.LabelSiparis) as Label;
                        if (lbl.Text.Contains(urunad))
                        {
                            sayac++;
                            lbl.Visible = false;
                        }
                    }
                    _LabelSiparis.Text = urunad + " X " + sayac.ToString() + "</br>";
                    break;
            }

        }

        protected void RadButtonIndirimliOdeme_Click(object sender, EventArgs e)
        {
            int _SiparisKey = Convert.ToInt32(RadGridHesaplar.SelectedValue);
            SiparisIndirimliOde(_SiparisKey);
        }

        protected void RadButtonTamaminiOdeme_Click(object sender, EventArgs e)
        {
            int _SiparisKey = Convert.ToInt32(RadGridHesaplar.SelectedValue);
            SiparisTamaminiOde(_SiparisKey);
        }

        protected void RadButtonParcaliOdeme_Click(object sender, EventArgs e)
        {
            int _SiparisKey = Convert.ToInt32(RadGridHesaplar.SelectedValue);

            var _RadWindowManager = Page.Master.FindControl(PageControl.RadWindowManagerProgram) as RadWindowManager;
            _RadWindowManager.Windows.Clear();

            var _RadWindow = new RadWindow
                {
                    Modal = true,
                    DestroyOnClose = true,
                    VisibleOnPageLoad = true,
                    EnableShadow = false,
                    Width = 500,
                    Height = 550,
                    RenderMode = RenderMode.Lightweight,
                    NavigateUrl = "PopUps/Program_Kasa_Islemleri_PopUp.aspx?SiparisKey=" + _SiparisKey,
                };

            _RadWindowManager.Windows.Add(_RadWindow);
        }

        protected void RadButtonSiparisIptali_Click(object sender, EventArgs e)
        {
            int _SiparisKey = Convert.ToInt32(RadGridHesaplar.SelectedValue);
            SiparisIptal(_SiparisKey);
        }

        protected void RadButtonUcretsizKapatma_Click(object sender, EventArgs e)
        {
            int _SiparisKey = Convert.ToInt32(RadGridHesaplar.SelectedValue);
            SiparisUcretsizKapat(_SiparisKey);
        }

        protected void RadButtonMutfakTeslim_Click(object sender, EventArgs e)
        {
            int _SiparisKey = Convert.ToInt32(RadGridHesaplar.SelectedValue);
            SiparisMutfakTeslim(_SiparisKey);
        }

        protected void RadButtonArama_Click(object sender, EventArgs e)
        {
            RadGridHesaplar.Rebind();
            ButtonAktifPasif(false);
        }

        protected void RadButtonMutfakYazdir_Click(object sender, EventArgs e)
        {
            int _SiparisKey = Convert.ToInt32(RadGridHesaplar.SelectedValue);
            RadWindowManagerProgram.Windows.Clear();

            var _RadWindow = new RadWindow
            {
                Modal = true,
                DestroyOnClose = true,
                VisibleOnPageLoad = true,
                EnableShadow = false,
                Width = 330,
                Height = 400,
                RenderMode = RenderMode.Lightweight,
                Behaviors = WindowBehaviors.None,
                NavigateUrl = "../Program/PopUps/Program_Yazdir_PopUp.aspx?T=M&Key=" + _SiparisKey,
            };
            RadWindowManagerProgram.Windows.Add(_RadWindow);
        }

        protected void RadButtonFisYazdir_Click(object sender, EventArgs e)
        {
            int _SiparisKey = Convert.ToInt32(RadGridHesaplar.SelectedValue);
            RadWindowManagerProgram.Windows.Clear();

            var _RadWindow = new RadWindow
            {
                Modal = true,
                DestroyOnClose = true,
                VisibleOnPageLoad = true,
                EnableShadow = false,
                Width = 330,
                Height = 400,
                RenderMode = RenderMode.Lightweight,
                Behaviors = WindowBehaviors.None,
                NavigateUrl = "../Program/PopUps/Program_Yazdir_PopUp.aspx?T=F&Key=" + _SiparisKey,
            };
            RadWindowManagerProgram.Windows.Add(_RadWindow);
        }

        #endregion

        #region [PRIVATE METHODS] ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private void SetInitialValues()
        {
            RadDateTimePickerBaslangicTarih.SelectedDate = DateTime.Now.Date;
            RadDateTimePickerBitisTarih.SelectedDate = DateTime.Now.Date.AddDays(1);

            string _Sayfa = Page.Request.Path;
            switch (_Sayfa)
            {
                case "/Program/Program_Mutfak.aspx":
                    SayfaTip = "M";
                    PanelMutfak.Visible = true;
                    RadGridHesaplar.Height = 400;
                    RadioButtonListMutfakSunum.Visible = true;

                    RadGridHesaplar.Columns[ToplamKolon].Display = false;
                    RadGridHesaplar.Columns[OdenenKolon].Display = false;
                    RadGridHesaplar.Width = Unit.Percentage(100);
                    break;
                case "/Program/Program_Kasa_Islemleri.aspx":
                    SayfaTip = "K";
                    PanelKasa.Visible = true;
                    RadGridHesaplar.Height = 380;
                    RadioButtonListOdenmeler.Visible = true;
                    break;
            }
        }

        private void ButtonAktifPasif(bool durum)
        {
            RadButtonMutfakYazdir.Enabled = durum;
            RadButtonFisYazdir.Enabled = durum;
            RadButtonTamaminiOdeme.Enabled = durum;
            RadButtonParcaliOdeme.Enabled = durum;
            RadButtonIndirimliOdeme.Enabled = durum;

            if (GirisYapanKullanici.KullaniciSiparisIptalYetki)
            {
                RadButtonSiparisIptali.Enabled = durum;
            }

            if (GirisYapanKullanici.KullaniciUcretsizSatisYetki)
            {
                RadButtonUcretsizKapatma.Enabled = durum;
            }

            RadButtonMutfakTeslim.Enabled = durum;
        }

        private void SiparisIndirimliOde(int pSiparisKey)
        {
            //siparisi ve masayı kapat
            Sipari _Sipari = _ProCafeDBEntities.Siparis.Single(p => p.SiparisKey == pSiparisKey);

            _Sipari.SiparisHesapKapatildiTarih = DateTime.Now;
            _Sipari.SiparisToplam = Convert.ToDecimal(LabelToplam.Text);
            _Sipari.SiparisOdenen =
                Convert.ToDecimal(RadTextBoxGenelToplam.Text == ""
                                      ? "0"
                                      : ((RadTextBoxGenelToplam.Value * 90d) / 100d).ToString());
            _Sipari.KasaOdemeKullaniciKey = GirisYapanKullanici.KullaniciKey;

            Masa _Masa = _Sipari.Masa;
            if (_Masa != null)
            {
                _Masa.MasaAcik = false;
            }

            _ProCafeDBEntities.SaveChanges();

            ButtonAktifPasif(false);

            RadGridHesaplar.Rebind();
        }

        private void SiparisTamaminiOde(int pSiparisKey)
        {
            //siparisi ve masayı kapat
            Sipari _Sipari = _ProCafeDBEntities.Siparis.Single(p => p.SiparisKey == pSiparisKey);

            _Sipari.SiparisHesapKapatildiTarih = DateTime.Now;
            _Sipari.SiparisToplam = Convert.ToDecimal(LabelToplam.Text);
            _Sipari.SiparisOdenen =
                Convert.ToDecimal(RadTextBoxGenelToplam.Text == "" ? "0" : RadTextBoxGenelToplam.Value.ToString());
            _Sipari.KasaOdemeKullaniciKey = GirisYapanKullanici.KullaniciKey;

            Masa _Masa = _Sipari.Masa;
            if (_Masa != null)
            {
                _Masa.MasaAcik = false;
            }

            _ProCafeDBEntities.SaveChanges();

            ButtonAktifPasif(false);

            RadGridHesaplar.Rebind();
        }

        private void SiparisIptal(int pSiparisKey)
        {
            //siparisi ve masayı kapat
            Sipari _Sipari = _ProCafeDBEntities.Siparis.Single(p => p.SiparisKey == pSiparisKey);

            _Sipari.SiparisIptal = true;
            _Sipari.SiparisHesapKapatildiTarih = DateTime.Now;
            _Sipari.SiparisToplam = Convert.ToDecimal(LabelToplam.Text);
            _Sipari.SiparisOdenen = 0;
            _Sipari.KasaOdemeKullaniciKey = GirisYapanKullanici.KullaniciKey;

            Masa _Masa = _Sipari.Masa;
            if (_Masa != null)
            {
                _Masa.MasaAcik = false;
            }

            _ProCafeDBEntities.SaveChanges();

            ButtonAktifPasif(false);

            RadGridHesaplar.Rebind();
        }

        private void SiparisUcretsizKapat(int pSiparisKey)
        {
            //siparisi ve masayı kapat
            Sipari _Sipari = _ProCafeDBEntities.Siparis.Single(p => p.SiparisKey == pSiparisKey);

            _Sipari.SiparisUcretsizKapatma = true;
            _Sipari.SiparisHesapKapatildiTarih = DateTime.Now;
            _Sipari.SiparisToplam = Convert.ToDecimal(LabelToplam.Text);
            _Sipari.SiparisOdenen = 0;
            _Sipari.KasaOdemeKullaniciKey = GirisYapanKullanici.KullaniciKey;

            Masa _Masa = _Sipari.Masa;
            if (_Masa != null)
            {
                _Masa.MasaAcik = false;
            }

            _ProCafeDBEntities.SaveChanges();

            ButtonAktifPasif(false);

            RadGridHesaplar.Rebind();
        }

        private void SiparisMutfakTeslim(int pSiparisKey)
        {
            //siparisi ve masayı kapat
            Sipari _Sipari = _ProCafeDBEntities.Siparis.Single(p => p.SiparisKey == pSiparisKey);

            _Sipari.SiparisMutfakOnayTarih = DateTime.Now;
            _Sipari.MutfakOnayKullaniciKey = GirisYapanKullanici.KullaniciKey;

            foreach (A_Siparis_Urun Siparis_Urun in _Sipari.A_Siparis_Urun)
            {
                Siparis_Urun.SiparisMutfakTeslim = true;
            }

            _ProCafeDBEntities.SaveChanges();

            RadGridHesaplar.Rebind();
        }

        #endregion

        #region [PUBLIC METHODS] ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        #endregion
    }
}