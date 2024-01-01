using System.ComponentModel.DataAnnotations;

namespace HastaneCostumeAPI.Models
{
    public class Iletisim
    {
        [Key]
        public int IletisimId { get; set; }

        [Required(ErrorMessage ="Boş geçmeyiniz")]
        [Display(Name ="Randevu Numarası")]
        public string RandevuNumarasi { get; set; }

        public string Mesaj { get; set; }

        public string IletisimNumarasi { get; set; }
    }
}
