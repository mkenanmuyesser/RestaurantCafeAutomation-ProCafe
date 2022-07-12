using System;
using System.Linq;
using System.Web.UI;
using ProCafe.Data;
using Telerik.Web.UI;

namespace ProCafe.Program.PopUps.Tanimlama
{
    public partial class Program_Tanimlamalar_Urun_Opsiyon_Islemleri_PopUp : Page
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

        private int? UrunOpsiyonTurKey
        {
            get
            {
                if (ViewState["UrunOpsiyonTurKey"] == null)
                {
                    return null;
                }
                else
                {
                    return Convert.ToInt32(ViewState["UrunOpsiyonTurKey"]);
                }
            }
            set { ViewState["UrunOpsiyonTurKey"] = value; }
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
            RadGridKullanici.DataSource = _ProCafeDBEntities.T_Urun_Opsiyon_Tur.ToList();
        }

        protected void RadGridKullanici_ItemCommand(object sender, GridCommandEventArgs e)
        {
            var dataItem = e.Item as GridDataItem;
            int key = Convert.ToInt32(dataItem.GetDataKeyValue("UrunOpsiyonTurKey"));
            T_Urun_Opsiyon_Tur _T_Urun_Opsiyon_Tur =
                _ProCafeDBEntities.T_Urun_Opsiyon_Tur.Single(p => p.UrunOpsiyonTurKey == key);

            switch (e.CommandName)
            {
                case "Delete":
                    _ProCafeDBEntities.T_Urun_Opsiyon_Tur.Remove(_T_Urun_Opsiyon_Tur);
                    _ProCafeDBEntities.SaveChanges();
                    break;
                case "Update":
                    UrunOpsiyonTurKey = key;
                    GuncelleBilgiDoldur();
                    break;
            }
        }

        protected void RadButtonKaydet_Click(object sender, EventArgs e)
        {
            var _T_Urun_Opsiyon_Tur = new T_Urun_Opsiyon_Tur();
            KaydetGuncelle(ref _T_Urun_Opsiyon_Tur);
            Temizle();
            RadGridKullanici.Rebind();
        }

        protected void RadButtonTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        protected void RadButtonGüncelle_Click(object sender, EventArgs e)
        {
            T_Urun_Opsiyon_Tur _T_Urun_Opsiyon_Tur =
                _ProCafeDBEntities.T_Urun_Opsiyon_Tur.Single(p => p.UrunOpsiyonTurKey == UrunOpsiyonTurKey);
            KaydetGuncelle(ref _T_Urun_Opsiyon_Tur);
            UrunOpsiyonTurKey = null;
            Temizle();
            ButtonGuncelleMod(false);
            RadGridKullanici.Rebind();
        }

        protected void RadButtonİptal_Click(object sender, EventArgs e)
        {
            UrunOpsiyonTurKey = null;
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
        }

        private void KaydetGuncelle(ref T_Urun_Opsiyon_Tur _T_Urun_Opsiyon_Tur)
        {
            _T_Urun_Opsiyon_Tur.UrunOpsiyonAd = RadTextBoxUrunOpsiyonAd.Text;

            //yeni opsiyon kaydet
            if (_T_Urun_Opsiyon_Tur.UrunOpsiyonTurKey == 0)
            {
                _ProCafeDBEntities.T_Urun_Opsiyon_Tur.Add(_T_Urun_Opsiyon_Tur);
            }
            //varolan opsiyon güncelle

            _ProCafeDBEntities.SaveChanges();
        }

        private void GuncelleBilgiDoldur()
        {
            RadTabStripTanimlama.SelectedIndex = 0;
            RadMultiPageTanimlama.SelectedIndex = 0;

            T_Urun_Opsiyon_Tur _T_Urun_Opsiyon_Tur =
                _ProCafeDBEntities.T_Urun_Opsiyon_Tur.Single(p => p.UrunOpsiyonTurKey == UrunOpsiyonTurKey);

            RadTextBoxUrunOpsiyonAd.Text = _T_Urun_Opsiyon_Tur.UrunOpsiyonAd;

            ButtonGuncelleMod(true);
        }

        private void Temizle()
        {
            RadTextBoxUrunOpsiyonAd.Text = string.Empty;

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