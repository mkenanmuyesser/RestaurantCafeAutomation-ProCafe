using System;
using System.Linq;
using System.Web.UI;
using ProCafe.Data;
using Telerik.Web.UI;

namespace ProCafe.Program.PopUps.Tanimlama
{
    public partial class Program_Tanimlamalar_Masa_Kat_Bolge_Islemleri_PopUp : Page
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

        private int? MasaKatBolgeKey
        {
            get
            {
                if (ViewState["MasaKatBolgeKey"] == null)
                {
                    return null;
                }
                else
                {
                    return Convert.ToInt32(ViewState["MasaKatBolgeKey"]);
                }
            }
            set { ViewState["MasaKatBolgeKey"] = value; }
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

        protected void RadGridMasaKatBolge_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            RadGridMasaKatBolge.DataSource = _ProCafeDBEntities.T_Masa_Kat_Bolge_Tur.ToList();
        }

        protected void RadGridMasaKatBolge_ItemCommand(object sender, GridCommandEventArgs e)
        {
            var dataItem = e.Item as GridDataItem;
            int key = Convert.ToInt32(dataItem.GetDataKeyValue("MasaKatBolgeKey"));
            T_Masa_Kat_Bolge_Tur _T_Masa_Kat_Bolge_Tur =
                _ProCafeDBEntities.T_Masa_Kat_Bolge_Tur.Single(p => p.MasaKatBolgeKey == key);

            switch (e.CommandName)
            {
                case "Delete":
                    //şu an işlem yaptığı kullanıcıyı veya

                    //son kalan 1 kullanıcıyı silemez
                    if (RadGridMasaKatBolge.Items.Count > 1)
                    {
                        _ProCafeDBEntities.T_Masa_Kat_Bolge_Tur.Remove(_T_Masa_Kat_Bolge_Tur);
                        _ProCafeDBEntities.SaveChanges();
                    }
                    else
                    {
                        RadWindowManagerTanimlama.RadAlert("Son kalan kat/bölgeyi silemezsiniz.", null, 25, "Uyarı",
                                                           null);
                    }
                    break;
                case "Update":
                    MasaKatBolgeKey = key;
                    GuncelleBilgiDoldur();
                    break;
            }
        }

        protected void RadButtonKaydet_Click(object sender, EventArgs e)
        {
            var _T_Masa_Kat_Bolge_Tur = new T_Masa_Kat_Bolge_Tur();
            KaydetGuncelle(ref _T_Masa_Kat_Bolge_Tur);
            Temizle();
            RadGridMasaKatBolge.Rebind();
        }

        protected void RadButtonTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        protected void RadButtonGüncelle_Click(object sender, EventArgs e)
        {
            T_Masa_Kat_Bolge_Tur _T_Masa_Kat_Bolge_Tur =
                _ProCafeDBEntities.T_Masa_Kat_Bolge_Tur.Single(p => p.MasaKatBolgeKey == MasaKatBolgeKey);
            KaydetGuncelle(ref _T_Masa_Kat_Bolge_Tur);
            MasaKatBolgeKey = null;
            Temizle();
            ButtonGuncelleMod(false);
            RadGridMasaKatBolge.Rebind();
        }

        protected void RadButtonİptal_Click(object sender, EventArgs e)
        {
            MasaKatBolgeKey = null;
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

        private void KaydetGuncelle(ref T_Masa_Kat_Bolge_Tur _T_Masa_Kat_Bolge_Tur)
        {
            _T_Masa_Kat_Bolge_Tur.MasaKatBolgeAd = RadTextBoxMasaKatBolgeAd.Text;

            //yeni kullanıcı kaydet
            if (_T_Masa_Kat_Bolge_Tur.MasaKatBolgeKey == 0)
            {
                _ProCafeDBEntities.T_Masa_Kat_Bolge_Tur.Add(_T_Masa_Kat_Bolge_Tur);
            }
            //varolan kullanıcıyı güncelle

            _ProCafeDBEntities.SaveChanges();
        }

        private void GuncelleBilgiDoldur()
        {
            RadTabStripTanimlama.SelectedIndex = 0;
            RadMultiPageTanimlama.SelectedIndex = 0;

            T_Masa_Kat_Bolge_Tur _T_Masa_Kat_Bolge_Tur =
                _ProCafeDBEntities.T_Masa_Kat_Bolge_Tur.Single(p => p.MasaKatBolgeKey == MasaKatBolgeKey);

            RadTextBoxMasaKatBolgeAd.Text = _T_Masa_Kat_Bolge_Tur.MasaKatBolgeAd;

            ButtonGuncelleMod(true);
        }

        private void Temizle()
        {
            RadTextBoxMasaKatBolgeAd.Text = string.Empty;

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