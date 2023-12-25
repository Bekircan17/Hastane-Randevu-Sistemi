using System.ComponentModel.DataAnnotations;

namespace HastaneRandevuSau.Models
{
    public class DoktorCalisma
    {
        [Key]
        public int CalismaId { get; set; }
        [Range(1,100)]
        public int DoktorId { get; set; }
        public  Doktor Doktor {get; set;}

        public string Gun { get; set; }
       
        public string mesaiAraligi { get; set; } // 10 13 , 13 17, 10 17
    }
}
