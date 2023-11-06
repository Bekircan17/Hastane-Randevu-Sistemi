namespace HastaneRandevuSistemi.Models
{
    public class KullaniciHesabi
    {
        public string KullaniciHesapAdi { get; set; }

        public string KullaniciHesapSoyadi { get; set; }

        public string KullaniciHesapTc { get; set; }

        public string KullaniciHesapTelefon { get; set; }

        public string KullaniciHesapIlce { get; set; }

        public int KullaniciId { get; set; }
        public Kullanici Kullanici { get; set; }


    }
}
