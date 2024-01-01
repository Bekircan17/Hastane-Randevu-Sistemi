using HastaneRandevuSau.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HastaneRandevuSau.Controllers
{
    public class MesajlarAPI : Controller
    {
        Uri url = new Uri("https://localhost:7054/api/IletisimAPI");
        private readonly HttpClient baglanti;

        public MesajlarAPI()
        {
            baglanti = new HttpClient();
            baglanti.BaseAddress = url;
        }
        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response = await baglanti.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string veri = await response.Content.ReadAsStringAsync();
                var mesajlar = JsonConvert.DeserializeObject<IEnumerable<Iletisim>>(veri);

                return View(mesajlar);

            }
            else
            {
                return View("Error");
            }

            
    }
}
}
