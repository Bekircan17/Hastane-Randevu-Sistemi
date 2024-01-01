using HastaneRandevuSau.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HastaneRandevuSau.Controllers
{
    public class DurumTrueAPI : Controller
    {
        Uri url = new Uri("https://localhost:7111/api/Iletisims");
        private readonly HttpClient baglanti;

        public DurumTrueAPI()
        {
            baglanti = new HttpClient();
            baglanti.BaseAddress = url;
        }
        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response = await baglanti.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string veriyakala = await response.Content.ReadAsStringAsync();
                var mesajlar = JsonConvert.DeserializeObject<IEnumerable<Randevu>>(veriyakala);

                return View(mesajlar);
            }
            else
            {
                return View("Error");
            }

            
    }
}
}
