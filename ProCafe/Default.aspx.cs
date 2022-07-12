using System;
using System.Linq;
using System.Web.UI;
using ProCafe.Class;
using ProCafe.Data;
using System.Threading;

namespace ProCafe
{
    public partial class Default : Page
    {
        #region [PRIVATE MEMBERS] ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private readonly ProCafeDBEntities _ProCafeDBEntities = new ProCafeDBEntities();

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

        protected void ButtonLogin_Click(object Source, EventArgs e)
        {
            string _KullaniciAdi = TextBoxUserName.Text;
            string _Parola = TextBoxPassword.Text;

            IQueryable<Kullanici> _KullaniciDizi = _ProCafeDBEntities.Kullanicis.Where(
                x =>
                x.KullaniciKullaniciAd.ToUpper() == _KullaniciAdi.ToUpper() &&
                x.KullaniciKullaniciParola.ToUpper() == _Parola.ToUpper());
            int _KullaniciSayisi = _KullaniciDizi.Count();

            if (_KullaniciSayisi == 1)
            {
                Kullanici _Kullanici = _KullaniciDizi.Single();
                Session["User"] = _Kullanici;
                Session["Tablet"] = DropDownListTabletSecim.SelectedItem.Text;

                //Mobile cihaz ise mobil sayfaya yönlendir
                string useragent = Request.UserAgent.ToLower();
                string _kullaniciAdi = _Kullanici.KullaniciAd;
                if ((useragent.Contains("iphone") || useragent.Contains("ipad") || DropDownListTabletSecim.SelectedItem.Text == "IPod") &&
                    _Kullanici.Kullanici_Giris_Yetki.KullaniciGirisYetkiMasaSiparisYetki)
                {
                    Response.Redirect("Program/Mobile/Mobile_Masa.aspx", false);
                }
                else
                {
                    Response.Redirect("Program/Program_Main.aspx", false);
                }
            }
            else if (_KullaniciSayisi == 0)
            {
                PageClass.MessageBox(this, "Kullanıcı veya şifre hatalı!");
                Session["User"] = null;
            }
            else
            {
                PageClass.MessageBox(this, "Bu kullanıcı adına sahip birden fazla kişi var!");
                Session["User"] = null;
            }
        }

        #endregion

        #region [PRIVATE METHODS] ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private void SetInitialValues()
        {
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("tr-TR");
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("tr-TR");
        }

        #endregion

        #region [PUBLIC METHODS] ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        #endregion
    }
}