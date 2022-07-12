using System;
using System.Linq;
using System.Web.UI;
using ProCafe.Data;
using Telerik.Web.UI;

namespace ProCafe.Program
{
    public partial class Program_Musteriler : Page
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

        private int? MusteriKey
        {
            get
            {
                if (ViewState["MusteriKey"] == null)
                {
                    return null;
                }
                else
                {
                    return Convert.ToInt32(ViewState["MusteriKey"]);
                }
            }
            set { ViewState["MusteriKey"] = value; }
        }

        private struct PageControl
        {
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

        protected void RadGridMusteri_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            RadGridMusteri.DataSource = _ProCafeDBEntities.Musteris.ToList();
        }

        protected void RadGridMusteri_ItemCommand(object sender, GridCommandEventArgs e)
        {
            var dataItem = e.Item as GridDataItem;
            int key = Convert.ToInt32(dataItem.GetDataKeyValue("MusteriKey"));
            Musteri _Musteri = _ProCafeDBEntities.Musteris.Single(p => p.MusteriKey == key);

            switch (e.CommandName)
            {
                case "Delete":
                    _ProCafeDBEntities.Musteris.Remove(_Musteri);
                    _ProCafeDBEntities.SaveChanges();
                    break;
                case "Update":
                    MusteriKey = key;
                    GuncelleBilgiDoldur();
                    break;
            }
        }

        protected void RadButtonKaydet_Click(object sender, EventArgs e)
        {
            var _Musteri = new Musteri();
            KaydetGuncelle(ref _Musteri);
            Temizle();
            RadGridMusteri.Rebind();
        }

        protected void RadButtonTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        protected void RadButtonGüncelle_Click(object sender, EventArgs e)
        {
            Musteri _Musteri = _ProCafeDBEntities.Musteris.Single(p => p.MusteriKey == MusteriKey);
            KaydetGuncelle(ref _Musteri);
            MusteriKey = null;
            Temizle();
            ButtonGuncelleMod(false);
            RadGridMusteri.Rebind();
        }

        protected void RadButtonİptal_Click(object sender, EventArgs e)
        {
            MusteriKey = null;
            Temizle();
            ButtonGuncelleMod(false);
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

            RadTextBoxMusteriTarih.SelectedDate = DateTime.Now;
        }

        private void KaydetGuncelle(ref Musteri _Musteri)
        {
            _Musteri.MusteriAd = RadTextBoxMusteriAd.Text;
            _Musteri.MusteriSoyad = RadTextBoxMusteriSoyad.Text;
            _Musteri.MusteriUnvan = RadTextBoxMusteriUnvan.Text;
            _Musteri.MusteriTarih = RadTextBoxMusteriTarih.SelectedDate == null
                                        ? DateTime.Now.Date
                                        : RadTextBoxMusteriTarih.SelectedDate.Value;
            _Musteri.MusteriTelefon = RadTextBoxMusteriTelefon.Text;
            _Musteri.MusteriAciklama = RadTextBoxMusteriAciklama.Text;

            //yeni müşteri kaydet
            if (_Musteri.MusteriKey == 0)
            {
                _ProCafeDBEntities.Musteris.Add(_Musteri);
            }

            //varolan müşteri güncelle

            _ProCafeDBEntities.SaveChanges();
        }

        private void GuncelleBilgiDoldur()
        {
            RadTabStripTanimlama.SelectedIndex = 0;
            RadMultiPageTanimlama.SelectedIndex = 0;

            Musteri _Musteri = _ProCafeDBEntities.Musteris.Single(p => p.MusteriKey == MusteriKey);

            RadTextBoxMusteriAd.Text = _Musteri.MusteriAd;
            RadTextBoxMusteriSoyad.Text = _Musteri.MusteriSoyad;
            RadTextBoxMusteriUnvan.Text = _Musteri.MusteriUnvan;
            RadTextBoxMusteriTarih.SelectedDate = _Musteri.MusteriTarih;
            RadTextBoxMusteriTelefon.Text = _Musteri.MusteriTelefon;
            RadTextBoxMusteriAciklama.Text = _Musteri.MusteriAciklama;

            ButtonGuncelleMod(true);
        }

        private void Temizle()
        {
            RadTextBoxMusteriAd.Text = string.Empty;
            RadTextBoxMusteriSoyad.Text = string.Empty;
            RadTextBoxMusteriUnvan.Text = string.Empty;
            RadTextBoxMusteriTarih.SelectedDate = DateTime.Now;
            RadTextBoxMusteriTelefon.Text = string.Empty;
            RadTextBoxMusteriAciklama.Text = string.Empty;

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