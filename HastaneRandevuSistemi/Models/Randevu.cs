using System.ComponentModel.DataAnnotations;

namespace HastaneRandevuSistemi.Models
{
    public class Randevu
    {
        [Key]
        public int RandevuId { get; set; }

        public int PoliklinikId { get; set; }
        public Poliklinik Poliklinik { get; set; }

        public int DoktorId { get; set; }
        public Doktor Doktor { get; set; }

        [Required(ErrorMessage = "Randevu Ayı Seçmeden Randevu Oluşturamazsınız")]
        [Display(Name = "Randevu Ayi")]
        public string RandevuAyi { get; set; } // 1- Ocak 2-Şubat 3-Mart 4- Nisan 5-Mayıs 6-Haziran 7-Temmuz 8-Ağustos 9-Eylül 10-Ekim 11-Kasım 12-Aralık

        [Required(ErrorMessage = "Randevu Gunu Seçmeden Randevu Oluşturamazsınız")]
        [Display(Name = "Randevu Gunu")]
        public string RandevuGunu { get; set; } // 1-Pazartesi 2-Salı 3-Çarşamba 4-Perşembe 5-Cuma

        [Required (ErrorMessage ="Randevu Saati Seçmeden Randevu Oluşturamazsınız")]
        [Display(Name ="Randevu Saati")]
        public string RandevuSaati { get; set; } // 10.00 11.00 13.00 14.00 15.00 16.00 17.00



    }
}
