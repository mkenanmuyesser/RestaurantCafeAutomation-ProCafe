using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using ProCafe.Data;
using Telerik.Web.UI;

namespace ProCafe.Program
{
    public partial class Program_Paket_Siparis : Page
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

        private int? SiparisKey
        {
            get
            {
                if (ViewState["SiparisKey"] == null)
                {
                    return null;
                }
                else
                {
                    return Convert.ToInt32(ViewState["SiparisKey"]);
                }
            }
            set { ViewState["SiparisKey"] = value; }
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

        protected void RadGridSiparis_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            List<Sipari> _SipariDizi;
            if (RadDateTimePickerBaslangicTarih.SelectedDate == null || RadDateTimePickerBitisTarih.SelectedDate == null)
            {
                _SipariDizi = _ProCafeDBEntities.Siparis.Where(p => p.MasaKey == null).ToList();
            }
            else
            {
                DateTime baslangic = RadDateTimePickerBaslangicTarih.SelectedDate.Value;
                DateTime bitis = RadDateTimePickerBitisTarih.SelectedDate.Value;
                _SipariDizi =
                    _ProCafeDBEntities.Siparis.Where(
                        p => p.MasaKey == null && p.SiparisAlindiTarih >= baslangic && p.SiparisAlindiTarih < bitis)
                                      .ToList();
            }
            RadGridSiparis.DataSource = _SipariDizi;
        }

        protected void RadGridSiparis_ItemCommand(object sender, GridCommandEventArgs e)
        {
            var dataItem = e.Item as GridDataItem;
            int key = Convert.ToInt32(dataItem.GetDataKeyValue("SiparisKey"));
            Sipari _Sipari = _ProCafeDBEntities.Siparis.Single(p => p.SiparisKey == key);

            switch (e.CommandName)
            {
                case "Delete":
                    _ProCafeDBEntities.Siparis.Remove(_Sipari);
                    _ProCafeDBEntities.SaveChanges();
                    break;
                case "Update":
                    SiparisKey = key;
                    GuncelleBilgiDoldur();
                    break;
                case "OpenPopup":
                    PopUpAc(key);
                    break;
            }
        }

        protected void RadButtonKaydet_Click(object sender, EventArgs e)
        {
            var _Sipari = new Sipari();
            KaydetGuncelle(ref _Sipari);
            Temizle();
            RadGridSiparis.Rebind();
            PopUpAc(_Sipari.SiparisKey);
        }

        protected void RadButtonTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        protected void RadButtonGüncelle_Click(object sender, EventArgs e)
        {
            Sipari _Sipari = _ProCafeDBEntities.Siparis.Single(p => p.SiparisKey == SiparisKey);
            KaydetGuncelle(ref _Sipari);
            SiparisKey = null;
            Temizle();
            ButtonGuncelleMod(false);
            RadGridSiparis.Rebind();
        }

        protected void RadButtonİptal_Click(object sender, EventArgs e)
        {
            SiparisKey = null;
            Temizle();
            ButtonGuncelleMod(false);
        }

        protected void RadButtonAra_Click(object sender, EventArgs e)
        {
            RadGridSiparis.Rebind();
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

            RadDateTimePickerBaslangicTarih.SelectedDate = DateTime.Now.Date;
            RadDateTimePickerBitisTarih.SelectedDate = DateTime.Now.Date.AddDays(1);
        }

        private void KaydetGuncelle(ref Sipari _Sipari)
        {
            _Sipari.SiparisAd = RadTextBoxSiparisAd.Text;
            _Sipari.SiparisSoyad = RadTextBoxSiparisSoyad.Text;
            _Sipari.SiparisTelefon = RadTextBoxSiparisTelefon.Text;
            _Sipari.SiparisAdres = RadTextBoxSiparisAdres.Text;
            _Sipari.SiparisAciklama = RadTextBoxSiparisAciklama.Text;

            //yeni sipariş kaydet
            if (_Sipari.SiparisKey == 0)
            {
                _Sipari.SiparisAlindiTarih = DateTime.Now;
                _Sipari.SiparisiAlanKullaniciKey = GirisYapanKullanici.KullaniciKey;
                _ProCafeDBEntities.Siparis.Add(_Sipari);
            }

            //varolan siparişi güncelle

            _ProCafeDBEntities.SaveChanges();
        }

        private void GuncelleBilgiDoldur()
        {
            RadTabStripTanimlama.SelectedIndex = 0;
            RadMultiPageTanimlama.SelectedIndex = 0;

            Sipari _Sipari = _ProCafeDBEntities.Siparis.Single(p => p.SiparisKey == SiparisKey);

            RadTextBoxSiparisAd.Text = _Sipari.SiparisAd;
            RadTextBoxSiparisSoyad.Text = _Sipari.SiparisSoyad;
            RadTextBoxSiparisTelefon.Text = _Sipari.SiparisTelefon;
            RadTextBoxSiparisAdres.Text = _Sipari.SiparisAdres;
            RadTextBoxSiparisAciklama.Text = _Sipari.SiparisAciklama;

            ButtonGuncelleMod(true);
        }

        private void Temizle()
        {
            RadTextBoxSiparisAd.Text = string.Empty;
            RadTextBoxSiparisSoyad.Text = string.Empty;
            RadTextBoxSiparisTelefon.Text = string.Empty;
            RadTextBoxSiparisAdres.Text = string.Empty;
            RadTextBoxSiparisAciklama.Text = string.Empty;

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

        private void PopUpAc(int key)
        {
            var _RadWindowManager = Page.Master.FindControl(PageControl.RadWindowManagerProgram) as RadWindowManager;
            _RadWindowManager.Windows.Clear();
            var _RadWindow = new RadWindow
                {
                    ID = "Program_Masa_Paket_Siparis_PopUp",
                    Modal = true,
                    DestroyOnClose = true,
                    VisibleOnPageLoad = true,
                    EnableShadow = false,
                    Width = 980,
                    Height = 690,
                    RenderMode = RenderMode.Lightweight,
                    NavigateUrl =
                        "PopUps/Program_Masa_Paket_Siparis_PopUp.aspx?SiparisTip=P&SiparisKey=" + key.ToString(),
                };
            _RadWindowManager.Windows.Add(_RadWindow);
        }

        #endregion

        #region [PUBLIC METHODS] ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        #endregion
    }
}