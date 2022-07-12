using System;
using System.Linq;
using System.Web.UI;
using ProCafe.Data;
using Telerik.Web.UI;

namespace ProCafe.Program.PopUps.Tanimlama
{
    public partial class Program_Tanimlamalar_Urun_Kategori_Islemleri_PopUp : Page
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

        private int? UrunKategoriTurKey
        {
            get
            {
                if (ViewState["UrunKategoriTurKey"] == null)
                {
                    return null;
                }
                else
                {
                    return Convert.ToInt32(ViewState["UrunKategoriTurKey"]);
                }
            }
            set { ViewState["UrunKategoriTurKey"] = value; }
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

        protected void RadGridUrunKategori_NeedDataSource(object sender, GridNeedDataSourceEventArgs e)
        {
            RadGridUrunKategori.DataSource =
                _ProCafeDBEntities.T_Urun_Kategori_Tur.OrderBy(p => p.UrunKategoriTurSiralama).ToList();
        }

        protected void RadGridUrunKategori_ItemCommand(object sender, GridCommandEventArgs e)
        {
            var dataItem = e.Item as GridDataItem;
            int key = Convert.ToInt32(dataItem.GetDataKeyValue("UrunKategoriTurKey"));
            T_Urun_Kategori_Tur _T_Urun_Kategori_Tur =
                _ProCafeDBEntities.T_Urun_Kategori_Tur.Single(p => p.UrunKategoriTurKey == key);

            switch (e.CommandName)
            {
                case "Delete":
                    //şu an işlem yaptığı kullanıcıyı veya

                    //son kalan 1 kategoriyi silemez
                    if (RadGridUrunKategori.Items.Count > 1)
                    {
                        _ProCafeDBEntities.T_Urun_Kategori_Tur.Remove(_T_Urun_Kategori_Tur);
                        _ProCafeDBEntities.SaveChanges();
                    }
                    else
                    {
                        RadWindowManagerTanimlama.RadAlert("Son kalan kategoriyi silemezsiniz.", null, 25, "Uyarı", null);
                    }
                    break;
                case "Update":
                    UrunKategoriTurKey = key;
                    GuncelleBilgiDoldur();
                    break;
            }
        }

        protected void RadButtonKaydet_Click(object sender, EventArgs e)
        {
            var _T_Urun_Kategori_Tur = new T_Urun_Kategori_Tur();
            KaydetGuncelle(ref _T_Urun_Kategori_Tur);
            Temizle();
            RadGridUrunKategori.Rebind();
        }

        protected void RadButtonTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        protected void RadButtonGüncelle_Click(object sender, EventArgs e)
        {
            T_Urun_Kategori_Tur _T_Urun_Kategori_Tur =
                _ProCafeDBEntities.T_Urun_Kategori_Tur.Single(p => p.UrunKategoriTurKey == UrunKategoriTurKey);
            KaydetGuncelle(ref _T_Urun_Kategori_Tur);
            UrunKategoriTurKey = null;
            Temizle();
            ButtonGuncelleMod(false);
            RadGridUrunKategori.Rebind();
        }

        protected void RadButtonİptal_Click(object sender, EventArgs e)
        {
            UrunKategoriTurKey = null;
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

            RadNumericTextBoxUrunKategoriTurSiralama.Value = 0;
        }

        private void KaydetGuncelle(ref T_Urun_Kategori_Tur _T_Urun_Kategori_Tur)
        {
            _T_Urun_Kategori_Tur.UrunKategoriTurAd = RadTextBoxUrunKategoriTurAd.Text;
            _T_Urun_Kategori_Tur.UrunKategoriTurSiralama =
                Convert.ToInt32(RadNumericTextBoxUrunKategoriTurSiralama.Text == ""
                                    ? "0"
                                    : RadNumericTextBoxUrunKategoriTurSiralama.Text);

            //yeni kategori kaydet
            if (_T_Urun_Kategori_Tur.UrunKategoriTurKey == 0)
            {
                _ProCafeDBEntities.T_Urun_Kategori_Tur.Add(_T_Urun_Kategori_Tur);
            }

            if (RadAsyncUploadUrunKategoriResim.UploadedFiles.Count == 1)
            {
                UploadedFile dosya = RadAsyncUploadUrunKategoriResim.UploadedFiles[0];
                int dosyauzunlugu = Convert.ToInt32(dosya.ContentLength);
                var resim = new byte[dosya.ContentLength];
                dosya.InputStream.BeginRead(resim, 0, dosyauzunlugu, null, null);
                _T_Urun_Kategori_Tur.UrunKategoriResim = resim;
            }
            //varolan kategori güncelle

            _ProCafeDBEntities.SaveChanges();
        }

        private void GuncelleBilgiDoldur()
        {
            RadTabStripTanimlama.SelectedIndex = 0;
            RadMultiPageTanimlama.SelectedIndex = 0;

            T_Urun_Kategori_Tur _T_Urun_Kategori_Tur =
                _ProCafeDBEntities.T_Urun_Kategori_Tur.Single(p => p.UrunKategoriTurKey == UrunKategoriTurKey);

            RadTextBoxUrunKategoriTurAd.Text = _T_Urun_Kategori_Tur.UrunKategoriTurAd;
            RadNumericTextBoxUrunKategoriTurSiralama.Value = _T_Urun_Kategori_Tur.UrunKategoriTurSiralama;

            ButtonGuncelleMod(true);
        }

        private void Temizle()
        {
            RadTextBoxUrunKategoriTurAd.Text = string.Empty;
            RadNumericTextBoxUrunKategoriTurSiralama.Value = 0;

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