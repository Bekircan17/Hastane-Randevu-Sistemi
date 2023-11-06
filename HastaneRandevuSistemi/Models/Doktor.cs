using System.ComponentModel.DataAnnotations;

namespace HastaneRandevuSistemi.Models
{
    public class Doktor
    {
        [Key]
        public int DoktorId { get; set; }

        [Required]
        [Display(Name ="Doktor Adı")]
        public string DoktorAdi { get; set; }

        [Required]
        [Display(Name = "Doktor Soyadı")]
        public string DoktorSoyadi { get; set; }
        
        public int PoliklinikId { get; set; }
        public Poliklinik Poliklinik { get; set; }  


        [Phone]
        public string DoktorTelefon { get;set; }


    }
}
