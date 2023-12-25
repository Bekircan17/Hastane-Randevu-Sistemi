using System.ComponentModel.DataAnnotations;

namespace HastaneRandevuSau.Models
{
    public class Iletisim
    {
        [Key]
        public string IletisimId { get; set; }

        [Required(ErrorMessage ="Boş geçmeyiniz")]
        [Display(Name ="Randevu Numarası")]
        public string RandevuNumarasi { get; set; }

        public string Mesaj { get; set; }

        public string IletisimNumarasi { get; set; }
    }
}
