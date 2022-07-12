using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Web.UI;
using System.Web.UI.HtmlControls;

using ProCafe.Class;
using ProCafe.Data;
using Telerik.Web.UI;

namespace ProCafe.Program
{
    public partial class Program : MasterPage
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

        public string OncekiSayfa
        {
            get
            {
                if (Session["OncekiSayfa"] == null)
                {
                    return "";
                }
                else
                {
                    return Session["OncekiSayfa"].ToString();
                }
            }
            set { Session["OncekiSayfa"] = value; }
        }

        private struct PageControl
        {
            public const string LabelBilgi = "LabelBilgi";
        }

        #endregion

        #region [PAGE] ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        protected void Page_Load(object sender, EventArgs e)
        {
            //meta ayarları
            //CometStateManager.RegisterAspNetCometScripts(Page);

            var meta = new HtmlMeta();
            meta.Name = "viewport";
            meta.ID = "ViewportMaster";
            if (Session["Tablet"].ToString() == "Asus")
            {
                meta.Content = "width=1024,height=768,initial-scale=0.67, user-scalable=true;";
            }
            else
            {
                meta.Content = "width=1024,height=768,initial-scale=1, user-scalable=true;";
            }
            MetaPlaceHolder.Controls.Add(meta);

            if (!IsPostBack)
            {
                SetInitialValues();
            }
        }

        #endregion

        #region [PAGE CONTROL EVENTS] ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        protected void RadButtonGeri_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(OncekiSayfa))
            {
                Response.Redirect(OncekiSayfa);
            }
        }

        protected void RadButtonHesapMakinasi_Click(object sender, EventArgs e)
        {
            RadWindowManagerProgram.Windows.Clear();

            var _RadWindow = new RadWindow
                {
                    Modal = false,
                    DestroyOnClose = true,
                    Width = 310,
                    Height = 430,
                    VisibleOnPageLoad = true,
                    NavigateUrl = "PopUps/Program_Hesap_Makinasi.aspx",
                };
            _RadWindow.Behaviors = WindowBehaviors.Close | WindowBehaviors.Move;
            RadWindowManagerProgram.Windows.Add(_RadWindow);
        }

        protected void RadButtonChat_Click(object sender, EventArgs e)
        {
            RadWindowManagerProgram.Windows.Clear();

            var _RadWindow = new RadWindow
                {
                    Modal = false,
                    DestroyOnClose = true,
                    Width = 500,
                    Height = 500,
                    VisibleOnPageLoad = true,
                    NavigateUrl = "PopUps/Program_Chat.aspx",
                };
            _RadWindow.OnClientBeforeClose = "doUnload";
            _RadWindow.Behaviors = WindowBehaviors.Close | WindowBehaviors.Move;
            RadWindowManagerProgram.Windows.Add(_RadWindow);
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

            if (Request.UrlReferrer != null && Request.UrlReferrer.ToString().Contains("PopUp") == false)
            {
                OncekiSayfa = Request.UrlReferrer == null ? null : Request.UrlReferrer.ToString();
            }

            DateTime bugun = DateTime.Now.Date;

            List<Sipari> bilgiler =
                _ProCafeDBEntities.Siparis.Where(
                    p =>
                    p.SiparisHesapKapatildiTarih == null &&
                    EntityFunctions.TruncateTime(p.SiparisAlindiTarih) == bugun)
                                  .OrderByDescending(p => p.SiparisKey)
                                  .Take(10)
                                  .ToList();
            foreach (Sipari _Sipari in bilgiler)
            {
                string bilgi = "";
                bilgi += _Sipari.Masa == null ? "PAKET " : "MASA NO : " + _Sipari.Masa.MasaNo + "---";
                bilgi += PageClass.ConvertTime(_Sipari.SiparisAlindiTarih) + "---";
                bilgi += _Sipari.A_Siparis_Urun.Sum(p => p.Urun.UrunFiyat).ToString() +
                         " TL...";

                var satir = new RadTickerItem {Text = bilgi};

                RadTickerBilgi.Items.Add(satir);
            }
        }

        #endregion

        #region [PUBLIC METHODS] ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        #endregion
    }
}