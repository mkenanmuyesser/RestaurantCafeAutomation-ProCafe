using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProCafe.Class;
using ProCafe.Data;

namespace ProCafe.Program.Mobile
{
    public partial class Mobile_Masa : Page
    {
        #region [PRIVATE MEMBERS] ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private readonly ProCafeDBEntities _ProCafeDBEntities = new ProCafeDBEntities();

        private string AcikMasaResim = "../../Image/MenuImages/edit_128x128.png";
        private string KapaliMasaResim = "../../Image/MenuImages/document_128x128.png";

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

        private struct PageControl
        {
            public const string LabelMasaNo = "LabelMasaNo";
            public const string ImageButtonMasa = "ImageButtonMasa";
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

        protected void DataListMasa_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            var _Masa = e.Item.DataItem as Masa;

            var labelMasaNo = e.Item.FindControl(PageControl.LabelMasaNo) as Label;
            labelMasaNo.Text = _Masa.MasaNo;

            var imageButtonMasa = e.Item.FindControl(PageControl.ImageButtonMasa) as ImageButton;
            imageButtonMasa.ImageUrl = _Masa.MasaAcik ? AcikMasaResim : KapaliMasaResim;
            imageButtonMasa.ToolTip = _Masa.MasaAciklama;
            imageButtonMasa.Attributes.Add("MasaDurum", _Masa.MasaAcik ? "A" : "K");
            imageButtonMasa.Attributes.Add("MasaKey", _Masa.MasaKey.ToString());
        }

        protected void ImageButtonMasa_Click(object sender, ImageClickEventArgs e)
        {
            var _ImageButton = sender as ImageButton;
            string masadurum = _ImageButton.Attributes["MasaDurum"];
            string masakey = _ImageButton.Attributes["MasaKey"];
            int _masakey = Convert.ToInt32(masakey);
            string sipariskey = null;

            Masa islemyapilanmasa = _ProCafeDBEntities.Masas.Single(p => p.MasaKey == _masakey);
            switch (masadurum)
            {
                case "A":
                    sipariskey =
                        islemyapilanmasa.Siparis.Single(p => p.SiparisHesapKapatildiTarih == null).SiparisKey.ToString();
                    break;
                case "K":
                    islemyapilanmasa.MasaAcik = true;

                    var yenisiparis = new Sipari
                        {
                            MasaKey = _masakey,
                            SiparisAlindiTarih = DateTime.Now,
                            SiparisYazildi = false,
                            SiparisiAlanKullaniciKey = GirisYapanKullanici.KullaniciKey,
                            //SiparisMutfakOnayTarih = 
                            //SiparisKey =                             
                            //SiparisHesapKapatildiTarih = 
                            //SiparisAciklama = 
                            //KullaniciKey =                              
                        };
                    _ProCafeDBEntities.Siparis.Add(yenisiparis);
                    _ProCafeDBEntities.SaveChanges();

                    sipariskey = yenisiparis.SiparisKey.ToString();
                    break;
            }
            string yol = "Mobile_Siparis.aspx?SiparisTip=M&MasaDurum=" + masadurum + "&MasaKey=" +
                         masakey + "&SiparisKey=" + sipariskey;
            Response.Redirect(yol);
        }

        protected void RadButtonYenile_Click(object sender, EventArgs e)
        {
            Response.Redirect(Request.Url.AbsoluteUri);
        }

        protected void RadButtonCikis_Click(object sender, EventArgs e)
        {
            Session["User"] = null;
            Response.Redirect("../../Default.aspx");
        }

        #endregion

        #region [PRIVATE METHODS] ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        private void SetInitialValues()
        {
            if (GirisYapanKullanici == null)
            {
                Response.Redirect("../../Default.aspx");
                return;
            }

            MasaLoad();
        }

        private void MasaLoad()
        {
            DataListMasa.DataSource = _ProCafeDBEntities.Masas.Where(p => p.MasaAktif).ToList().OrderBy(p => p.MasaSira);
            DataListMasa.DataBind();
        }

        #endregion

        #region [PUBLIC METHODS] ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        #endregion
    }
}