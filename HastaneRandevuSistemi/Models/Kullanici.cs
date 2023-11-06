using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HastaneRandevuSistemi.Models
{
    public class Kullanici : IdentityUser<int>
    {
        public string KullaniciAdi { get; set; }

        public string KullaniciSoyadi { get; set; }

        public string KullaniciTc { get; set; }

        public string KullaniciTelefon { get; set; }

        public List<KullaniciHesabi> KullaniciHesabis { get; set; } 
    }
}
