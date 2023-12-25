using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Xml.Linq;

namespace HastaneRandevuSau.Models
{
    public class Doktor
    {
        [Key]
        public int DoktorId { get; set; }

        [Required]
        [Display(Name = "Doktor Adı")]
        public string DoktorAdi { get; set; }

        [Required]
        [Display(Name = "Doktor Soyadı")]
        public string DoktorSoyadi { get; set; }

        [Required(ErrorMessage = "PoliklinikAdi")]
        public string uzmanlikAlani { get; set; }

        [Phone]
        public string DoktorTelefon { get; set; }

        public ICollection<Randevu>? Randevular { get; set; }
        public ICollection<DoktorCalisma>? DoktorCalisma { get; set; }
    }
}
