using System;
using System.Linq;
using System.Web.UI;
using ProCafe.Data;
using Telerik.Web.UI;

namespace ProCafe.Program
{
    public partial class Program_Ayarlar : Page
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

        protected void RadButtonKaydet_Click(object sender, EventArgs e)
        {
            Genel_Ayar _Genel_Ayar = _ProCafeDBEntities.Genel_Ayar.Single();
            KaydetGuncelle(ref _Genel_Ayar);
        }

        protected void RadButtonİptal_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.Url.AbsoluteUri);
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

            Genel_Ayar _Genel_Ayar = _ProCafeDBEntities.Genel_Ayar.Single();

            RadTextBoxGenelSirketAd.Text = _Genel_Ayar.GenelSirketAd;
            RadTextBoxGenelFaturaBilgi.Text = _Genel_Ayar.GenelFaturaBilgi;
            RadTextBoxGenelFaturaMesaj.Text = _Genel_Ayar.GenelFaturaMesaj;
            CheckBoxGenelMutfakKullanimi.Checked = _Genel_Ayar.GenelMutfakKullanimi;
            CheckBoxGenelKdvDahil.Checked = _Genel_Ayar.GenelKdvDahil;
            RadTextBoxIndirimOran.Value = _Genel_Ayar.GenelIndirimOran;
        }

        private void KaydetGuncelle(ref Genel_Ayar _Genel_Ayar)
        {
            _Genel_Ayar.GenelSirketAd = RadTextBoxGenelSirketAd.Text;
            _Genel_Ayar.GenelFaturaBilgi = RadTextBoxGenelFaturaBilgi.Text;
            _Genel_Ayar.GenelFaturaMesaj = RadTextBoxGenelFaturaMesaj.Text;
            _Genel_Ayar.GenelMutfakKullanimi = CheckBoxGenelMutfakKullanimi.Checked;
            _Genel_Ayar.GenelKdvDahil = CheckBoxGenelKdvDahil.Checked;
            _Genel_Ayar.GenelIndirimOran = RadTextBoxIndirimOran.Value == null
                                               ? (byte)0
                                               : Convert.ToByte(RadTextBoxIndirimOran.Value);

            if (RadAsyncUploadGenelSirketLogo.UploadedFiles.Count == 1)
            {
                UploadedFile dosya = RadAsyncUploadGenelSirketLogo.UploadedFiles[0];
                int dosyauzunlugu = Convert.ToInt32(dosya.ContentLength);
                var logo = new byte[dosya.ContentLength];
                dosya.InputStream.BeginRead(logo, 0, dosyauzunlugu, null, null);
                _Genel_Ayar.GenelSirketLogo = logo;
            }

            _ProCafeDBEntities.SaveChanges();
        }

        #endregion

        #region [PUBLIC METHODS] ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        #endregion
    }
}