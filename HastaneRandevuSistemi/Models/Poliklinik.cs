using System.ComponentModel.DataAnnotations;

namespace HastaneRandevuSistemi.Models
{
    public class Poliklinik
    {
        [Key]
        public int PoliklinikId { get; set; }

        [Required]
        [MaxLength(25)]
        [Display (Name ="Poliklinik Adı")]
        public string PoliklinikAdi { get; set; }


    }
}
