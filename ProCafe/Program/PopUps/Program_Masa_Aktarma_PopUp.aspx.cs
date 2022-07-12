using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using ProCafe.Class;
using ProCafe.Data;

namespace ProCafe.Program.PopUps
{
    public partial class Program_Masa_Aktarma_PopUp : Page
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

        protected void RadButtonAktar_Click(object sender, EventArgs e)
        {
            if (RadListBoxAcik.SelectedIndex == -1 || RadListBoxKapali.SelectedIndex == -1)
            {
                return;
            }

            int acikmasakey = Convert.ToInt32(RadListBoxAcik.SelectedValue);
            int aktarilacakmasakey = Convert.ToInt32(RadListBoxKapali.SelectedValue);

            //1.açık olan siparişi bul ve masa idsini değiştir
            Sipari acikmasasiparis = _ProCafeDBEntities.Siparis.Where(p => p.SiparisHesapKapatildiTarih == null && p.MasaKey == acikmasakey).Single();
            acikmasasiparis.MasaKey = aktarilacakmasakey;

            //2.acikmasayı kapat
            Masa kapatilacakmasa = _ProCafeDBEntities.Masas.Single(p => p.MasaKey == acikmasakey);
            kapatilacakmasa.MasaAcik = false;

            //3.aktarılan masayı aç
            Masa acilacakmasa = _ProCafeDBEntities.Masas.Single(p => p.MasaKey == aktarilacakmasakey);
            acilacakmasa.MasaAcik = true;

            _ProCafeDBEntities.SaveChanges();

            Kapat();
        }

        protected void RadButtonCikis_Click(object sender, EventArgs e)
        {
            Kapat();
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

            //sipariş açık olan masalar gelsin
            RadListBoxAcik.DataSource = _ProCafeDBEntities.Masas.Where(p => p.MasaAcik).OrderBy(p => p.MasaSira).ToList();
            RadListBoxAcik.DataBind();
            RadListBoxKapali.DataSource = _ProCafeDBEntities.Masas.Where(p => !p.MasaAcik).OrderBy(p => p.MasaSira).ToList();
            RadListBoxKapali.DataBind();
        }

        private void Kapat()
        {
            string script = "<script>CloseOnReload()</" + "script>";
            Page.ClientScript.RegisterStartupScript(GetType(), "CloseOnReload", script);
        }

        #endregion

        #region [PUBLIC METHODS] ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        #endregion
    }
}