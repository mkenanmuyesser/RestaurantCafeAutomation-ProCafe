using System;
using System.Collections.Generic;
using System.Linq;
using ProCafe.Data;
using Telerik.Web.UI;

namespace ProCafe.UserControl
{
    public partial class Rezervasyon_Not_Hatirlatma_User_Control : System.Web.UI.UserControl
    {
        #region [PRIVATE MEMBERS] ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private readonly ProCafeDBEntities _ProCafeDBEntities = new ProCafeDBEntities();
        private int MasaKolon = 3;

        private int? RezervasyonNotHatirlatmaKey
        {
            get
            {
                if (ViewState["RezervasyonNotHatirlatmaKey"] == null)
                {
                    return null;
                }
                else
                {
                    return Convert.ToInt32(ViewState["RezervasyonNotHatirlatmaKey"]);
                }
            }
            set { ViewState["RezervasyonNotHatirlatmaKey"] = value; }
        }

        private string SayfaTip
        {
            get { return ViewState["SayfaTip"].ToString(); }
            set { ViewState["SayfaTip"] = value; }
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

        protected void RadGridRezervasyon_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            List<Rezervasyon_Not_Hatirlatma> _Rezervasyon_Not_HatirlatmaDizi;
            if (RadDateTimePickerBaslangicTarih.SelectedDate == null ||
                RadDateTimePickerBitisTarih.SelectedDate == null)
            {
                switch (SayfaTip)
                {
                    case "R":
                        _Rezervasyon_Not_HatirlatmaDizi =
                            _ProCafeDBEntities.Rezervasyon_Not_Hatirlatma.Where(p => p.RezervasyonNotHatirlatmaTip)
                                              .ToList();
                        break;
                    case "NH":
                        _Rezervasyon_Not_HatirlatmaDizi =
                            _ProCafeDBEntities.Rezervasyon_Not_Hatirlatma.Where(
                                p => p.RezervasyonNotHatirlatmaTip == false).ToList();
                        break;
                    default:
                        _Rezervasyon_Not_HatirlatmaDizi = _ProCafeDBEntities.Rezervasyon_Not_Hatirlatma.ToList();
                        break;
                }
            }
            else
            {
                DateTime baslangic = RadDateTimePickerBaslangicTarih.SelectedDate.Value;
                DateTime bitis = RadDateTimePickerBitisTarih.SelectedDate.Value;

                switch (SayfaTip)
                {
                    case "R":
                        _Rezervasyon_Not_HatirlatmaDizi =
                            _ProCafeDBEntities.Rezervasyon_Not_Hatirlatma.Where(
                                p =>
                                p.RezervasyonNotHatirlatmaTip && p.RezervasyonNotHatirlatmaTarihSaat >= baslangic &&
                                p.RezervasyonNotHatirlatmaTarihSaat < bitis).ToList();
                        break;
                    case "NH":
                        _Rezervasyon_Not_HatirlatmaDizi =
                            _ProCafeDBEntities.Rezervasyon_Not_Hatirlatma.Where(
                                p =>
                                p.RezervasyonNotHatirlatmaTip == false &&
                                p.RezervasyonNotHatirlatmaTarihSaat >= baslangic &&
                                p.RezervasyonNotHatirlatmaTarihSaat < bitis).ToList();
                        break;
                    default:
                        _Rezervasyon_Not_HatirlatmaDizi = _ProCafeDBEntities.Rezervasyon_Not_Hatirlatma.ToList();
                        break;
                }
            }

            RadGridRezervasyon.DataSource = _Rezervasyon_Not_HatirlatmaDizi;
        }

        protected void RadGridRezervasyon_ItemCommand(object sender, GridCommandEventArgs e)
        {
            var dataItem = e.Item as GridDataItem;
            int key = Convert.ToInt32(dataItem.GetDataKeyValue("RezervasyonNotHatirlatmaKey"));
            Rezervasyon_Not_Hatirlatma _Rezervasyon_Not_Hatirlatma =
                _ProCafeDBEntities.Rezervasyon_Not_Hatirlatma.Single(p => p.RezervasyonNotHatirlatmaKey == key);

            switch (e.CommandName)
            {
                case "Delete":
                    _ProCafeDBEntities.Rezervasyon_Not_Hatirlatma.Remove(_Rezervasyon_Not_Hatirlatma);
                    _ProCafeDBEntities.SaveChanges();
                    break;
                case "Update":
                    RezervasyonNotHatirlatmaKey = key;
                    GuncelleBilgiDoldur();
                    break;
            }
        }

        protected void RadButtonKaydet_Click(object sender, EventArgs e)
        {
            var _Rezervasyon_Not_Hatirlatma = new Rezervasyon_Not_Hatirlatma();
            KaydetGuncelle(ref _Rezervasyon_Not_Hatirlatma);
            Temizle();
            RadGridRezervasyon.Rebind();
        }

        protected void RadButtonTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        protected void RadButtonGüncelle_Click(object sender, EventArgs e)
        {
            Rezervasyon_Not_Hatirlatma _Rezervasyon_Not_Hatirlatma =
                _ProCafeDBEntities.Rezervasyon_Not_Hatirlatma.Single(
                    p => p.RezervasyonNotHatirlatmaKey == RezervasyonNotHatirlatmaKey);
            KaydetGuncelle(ref _Rezervasyon_Not_Hatirlatma);
            RezervasyonNotHatirlatmaKey = null;
            Temizle();
            ButtonGuncelleMod(false);
            RadGridRezervasyon.Rebind();
        }

        protected void RadButtonİptal_Click(object sender, EventArgs e)
        {
            RezervasyonNotHatirlatmaKey = null;
            Temizle();
            ButtonGuncelleMod(false);
        }

        protected void RadButtonArama_Click(object sender, EventArgs e)
        {
            RadGridRezervasyon.Rebind();
        }

        #endregion

        #region [PRIVATE METHODS] ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private void SetInitialValues()
        {
            RadDateTimePickerBaslangicTarih.SelectedDate = DateTime.Now.Date;
            RadDateTimePickerBitisTarih.SelectedDate = DateTime.Now.Date.AddDays(1);

            RadDropDownListMasa.DataSource = _ProCafeDBEntities.Masas.ToList();
            RadDropDownListMasa.DataBind();
            RadDateInputRezervasyonNotHatirlatmaTarihSaat.SelectedDate = DateTime.Now;

            string _Sayfa = Page.Request.Path;
            switch (_Sayfa)
            {
                case "/Program/Program_Rezervasyon.aspx":
                    SayfaTip = "R";

                    break;
                case "/Program/Program_Notlar_Hatirlatmalar.aspx":
                    SayfaTip = "NH";
                    RadGridRezervasyon.Columns[MasaKolon].Visible = false;
                    RadGridRezervasyon.MasterTableView.NoMasterRecordsText = "Not/Hatırlatma bulunamadı.";
                    LabelMasa.Visible = false;
                    RadDropDownListMasa.Visible = false;
                    RadTabStripTanimlama.Tabs[0].Text = "Notlar-Hatırlatmalar Kaydet";
                    RadTabStripTanimlama.Tabs[1].Text = "Notlar-Hatırlatmalar Düzenle/Sil";
                    break;
            }
        }

        private void KaydetGuncelle(ref Rezervasyon_Not_Hatirlatma _Rezervasyon_Not_Hatirlatma)
        {
            _Rezervasyon_Not_Hatirlatma.RezervasyonNotHatirlatmaTarihSaat =
                RadDateInputRezervasyonNotHatirlatmaTarihSaat.SelectedDate == null
                    ? DateTime.Now.Date
                    : RadDateInputRezervasyonNotHatirlatmaTarihSaat.SelectedDate.Value;
            _Rezervasyon_Not_Hatirlatma.RezervasyonNotHatirlatmaAciklama =
                RadTextBoxRezervasyonNotHatirlatmaAciklama.Text;
            switch (SayfaTip)
            {
                case "R":
                    _Rezervasyon_Not_Hatirlatma.MasaKey = Convert.ToInt32(RadDropDownListMasa.SelectedValue);
                    _Rezervasyon_Not_Hatirlatma.RezervasyonNotHatirlatmaTip = true;
                    break;
                case "NH":
                    _Rezervasyon_Not_Hatirlatma.MasaKey = null;
                    _Rezervasyon_Not_Hatirlatma.RezervasyonNotHatirlatmaTip = false;
                    break;
            }

            //yeni rezervasyon kaydet
            if (_Rezervasyon_Not_Hatirlatma.RezervasyonNotHatirlatmaKey == 0)
            {
                _ProCafeDBEntities.Rezervasyon_Not_Hatirlatma.Add(_Rezervasyon_Not_Hatirlatma);
            }
            //varolan rezervasyon güncelle

            _ProCafeDBEntities.SaveChanges();
        }

        private void GuncelleBilgiDoldur()
        {
            RadTabStripTanimlama.SelectedIndex = 0;
            RadMultiPageTanimlama.SelectedIndex = 0;

            Rezervasyon_Not_Hatirlatma _Rezervasyon_Not_Hatirlatma =
                _ProCafeDBEntities.Rezervasyon_Not_Hatirlatma.Single(
                    p => p.RezervasyonNotHatirlatmaKey == RezervasyonNotHatirlatmaKey);

            RadDropDownListMasa.SelectedValue = _Rezervasyon_Not_Hatirlatma.MasaKey.ToString();
            RadDateInputRezervasyonNotHatirlatmaTarihSaat.SelectedDate =
                _Rezervasyon_Not_Hatirlatma.RezervasyonNotHatirlatmaTarihSaat;
            RadTextBoxRezervasyonNotHatirlatmaAciklama.Text =
                _Rezervasyon_Not_Hatirlatma.RezervasyonNotHatirlatmaAciklama;

            ButtonGuncelleMod(true);
        }

        private void Temizle()
        {
            RadDropDownListMasa.SelectedIndex = 0;
            RadTextBoxRezervasyonNotHatirlatmaAciklama.Text = string.Empty;
            RadDateInputRezervasyonNotHatirlatmaTarihSaat.SelectedDate = DateTime.Now;

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