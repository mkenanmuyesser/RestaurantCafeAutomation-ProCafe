using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using ProCafe.Class;
using ProCafe.Data;

namespace ProCafe.Program.PopUps
{
    public partial class Program_Kasa_Islemleri_PopUp : Page
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

        private List<SiparisUrunClass> AlinanSiparisler
        {
            get
            {
                if (ViewState["AlinanSiparisler"] == null)
                {
                    ViewState["AlinanSiparisler"] = new List<SiparisUrunClass>();
                }
                var _AlinanSiparisler = ViewState["AlinanSiparisler"] as List<SiparisUrunClass>;
                return _AlinanSiparisler;
            }
            set { ViewState["AlinanSiparisler"] = value; }
        }

        private List<SiparisUrunClass> OdenenSiparisler
        {
            get
            {
                if (ViewState["OdenenSiparisler"] == null)
                {
                    ViewState["OdenenSiparisler"] = new List<SiparisUrunClass>();
                }
                var _OdenenSiparisler = ViewState["OdenenSiparisler"] as List<SiparisUrunClass>;
                return _OdenenSiparisler;
            }
            set { ViewState["OdenenSiparisler"] = value; }
        }

        private List<SiparisUrunClass> SilinenSiparisler
        {
            get
            {
                if (ViewState["SilinenSiparisler"] == null)
                {
                    ViewState["SilinenSiparisler"] = new List<SiparisUrunClass>();
                }
                var _SilinenSiparisler = ViewState["SilinenSiparisler"] as List<SiparisUrunClass>;
                return _SilinenSiparisler;
            }
            set { ViewState["SilinenSiparisler"] = value; }
        }

        public int SiparisKey
        {
            get
            {
                return Convert.ToInt32(Request.QueryString["SiparisKey"]);
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

        protected void RadButtonEkle_Click(object sender, EventArgs e)
        {
            if (RadListBoxAlinanSiparisler.SelectedIndex != -1)
            {
                int secilensipariskey = Convert.ToInt32(RadListBoxAlinanSiparisler.SelectedValue);
                SiparisUrunClass secilensiparis = AlinanSiparisler.Single(p => p.SiparisUrunKey == secilensipariskey);

                List<SiparisUrunClass> siparisler =
                    OdenenSiparisler.Where(p => p.SiparisUrunKey == secilensipariskey).ToList();

                var _SiparisUrunClass = new SiparisUrunClass
                    {
                        SiparisUrunKey = secilensiparis.SiparisUrunKey,
                        UrunKey = secilensiparis.UrunKey,
                        UrunAd = secilensiparis.UrunAd,
                        UrunFiyat = secilensiparis.UrunFiyat,
                    };
                OdenenSiparisler.Add(_SiparisUrunClass);
                AlinanSiparisler.Remove(secilensiparis);


                ViewState["AlinanSiparisler"] = AlinanSiparisler;
                ViewState["OdenenSiparisler"] = OdenenSiparisler;

                Doldur();
            }
        }

        protected void RadButtonKaldir_Click(object sender, EventArgs e)
        {
            if (RadListBoxOdenenSiparisler.SelectedIndex != -1)
            {
                int secilensipariskey = Convert.ToInt32(RadListBoxOdenenSiparisler.SelectedValue);
                SiparisUrunClass secilensiparis = OdenenSiparisler.Single(p => p.SiparisUrunKey == secilensipariskey);

                List<SiparisUrunClass> siparisler =
                    AlinanSiparisler.Where(p => p.SiparisUrunKey == secilensipariskey).ToList();

                var _SiparisUrunClass = new SiparisUrunClass
                    {
                        SiparisUrunKey = secilensiparis.SiparisUrunKey,
                        UrunKey = secilensiparis.UrunKey,
                        UrunAd = secilensiparis.UrunAd,
                        UrunFiyat = secilensiparis.UrunFiyat,
                    };
                AlinanSiparisler.Add(_SiparisUrunClass);

                OdenenSiparisler.Remove(secilensiparis);
                SilinenSiparisler.Add(secilensiparis);

                ViewState["AlinanSiparisler"] = AlinanSiparisler;
                ViewState["OdenenSiparisler"] = OdenenSiparisler;

                Doldur();
            }
        }

        protected void RadButtonSifirla_Click(object sender, EventArgs e)
        {
            SetInitialValues();
        }

        protected void RadButtonOde_Click(object sender, EventArgs e)
        {
            foreach (SiparisUrunClass siparisurun in OdenenSiparisler)
            {
                List<A_Siparis_Urun> _A_Siparis_UrunOdenen =
                    _ProCafeDBEntities.A_Siparis_Urun.Where(
                        p => p.SiparisUrunKey == siparisurun.SiparisUrunKey).ToList();

                A_Siparis_Urun _A_Siparis_Urun = _A_Siparis_UrunOdenen.Single();
                _A_Siparis_Urun.SiparisParca = true;
            }

            //sipariş parçalı olarak işaretlenecek
            Sipari _Sipari = _ProCafeDBEntities.Siparis.Single(p => p.SiparisKey == SiparisKey);
            _Sipari.SiparisParcali = true;
            _Sipari.SiparisOdenen += RadNumericTextBoxOdenenSiparislerToplam.Value == null
                                        ? 0
                                        : Convert.ToDecimal(RadNumericTextBoxOdenenSiparislerToplam.Value.ToString());

            if (RadListBoxAlinanSiparisler.Items.Count == 0)
            {
                _Sipari.SiparisHesapKapatildiTarih = DateTime.Now;
                if (_Sipari.Masa != null)
                {
                    _Sipari.Masa.MasaAcik = false;
                    _Sipari.KasaOdemeKullaniciKey = GirisYapanKullanici.KullaniciKey;
                }
            }

            //kaydet
            _ProCafeDBEntities.SaveChanges();

            Kapat();
        }

        protected void RadButtonIndirimliOde_Click(object sender, EventArgs e)
        {
            foreach (SiparisUrunClass siparisurun in OdenenSiparisler)
            {
                List<A_Siparis_Urun> _A_Siparis_UrunOdenen =
                    _ProCafeDBEntities.A_Siparis_Urun.Where(
                        p => p.SiparisUrunKey == siparisurun.SiparisUrunKey).ToList();

                A_Siparis_Urun _A_Siparis_Urun = _A_Siparis_UrunOdenen.Single();
                _A_Siparis_Urun.SiparisParca = true;
            }


            foreach (SiparisUrunClass odenensilinecek in SilinenSiparisler)
            {
                List<A_Siparis_Urun> silinecekler =
                    _ProCafeDBEntities.A_Siparis_Urun.Where(
                        p =>
                        p.SiparisUrunKey == odenensilinecek.SiparisUrunKey).ToList();

                A_Siparis_Urun _A_Siparis_Urun = silinecekler.Single();
                _A_Siparis_Urun.SiparisParca = false;
            }

            decimal indirimoran = _ProCafeDBEntities.Genel_Ayar.Single().GenelIndirimOran;

            //sipariş parçalı olarak işaretlenecek
            Sipari _Sipari = _ProCafeDBEntities.Siparis.Single(p => p.SiparisKey == SiparisKey);
            _Sipari.SiparisParcali = true;
            _Sipari.SiparisOdenen += RadNumericTextBoxOdenenSiparislerToplam.Value == null
                                        ? 0
                                        : ((Convert.ToDecimal(RadNumericTextBoxOdenenSiparislerToplam.Value.ToString()) *
                                            indirimoran) / 100m);

            if (RadListBoxAlinanSiparisler.Items.Count == 0)
            {
                _Sipari.SiparisHesapKapatildiTarih = DateTime.Now;
                if (_Sipari.Masa != null)
                {
                    _Sipari.Masa.MasaAcik = false;
                    _Sipari.KasaOdemeKullaniciKey = GirisYapanKullanici.KullaniciKey;
                }
            }

            //kaydet
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

            List<A_Siparis_Urun> _A_Siparis_UrunAlinan =
                _ProCafeDBEntities.A_Siparis_Urun.Where(p => p.SiparisParca == false && p.SiparisKey == SiparisKey)
                                  .ToList();

            var _AlinanDizi = new List<SiparisUrunClass>();
            _A_Siparis_UrunAlinan.ForEach(p => SiparisUrunClass.SiparisUrunClassDonusturucu(ref _AlinanDizi, p));

            var _OdenenDizi = new List<SiparisUrunClass>();

            AlinanSiparisler = _AlinanDizi.ToList();
            OdenenSiparisler = _OdenenDizi;

            Doldur();
        }

        private void Doldur()
        {
            RadListBoxAlinanSiparisler.DataSource = AlinanSiparisler;
            RadListBoxAlinanSiparisler.DataBind();

            RadListBoxOdenenSiparisler.DataSource = OdenenSiparisler;
            RadListBoxOdenenSiparisler.DataBind();

            RadTextBoxAlinanSiparislerToplam.Value =
                Convert.ToDouble(AlinanSiparisler.Sum(p => p.UrunFiyat));
            RadNumericTextBoxOdenenSiparislerToplam.Value =
                Convert.ToDouble(OdenenSiparisler.Sum(p => p.UrunFiyat));
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