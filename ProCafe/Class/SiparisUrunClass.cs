using System;
using System.Collections.Generic;
using ProCafe.Data;

namespace ProCafe.Class
{
    [Serializable]
    public class SiparisUrunClass
    {
        public int SiparisUrunKey { get; set; }
        public int UrunKey { get; set; }
        public string UrunAd { get; set; }
        public decimal UrunFiyat { get; set; }

        public static void SiparisUrunClassDonusturucu(ref List<SiparisUrunClass> pDizi, A_Siparis_Urun pUrun)
        {
            var _SiparisUrunClass = new SiparisUrunClass
                {
                    SiparisUrunKey = pUrun.SiparisUrunKey,
                    UrunKey = pUrun.UrunKey,
                    UrunAd = pUrun.Urun.UrunAd,
                    UrunFiyat = pUrun.Urun.UrunFiyat,
                };
            pDizi.Add(_SiparisUrunClass);
        }

        public override string ToString()
        {
            return UrunAd;
        }
    }
}