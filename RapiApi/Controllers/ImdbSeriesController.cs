using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapiApi.Models;

namespace RapiApi.Controllers
{
    public class ImdbSeriesController : Controller
    {
        public async Task<IActionResult> Index()
        {
            
            var client = new HttpClient(); //-->consume işlemlerinde gibi client oluşturdu.
            var request = new HttpRequestMessage //httprequestmessage sınıfından örenk alan bir değişken oluşturmuş içnde parametreler var
            {
                Method = HttpMethod.Get, //istek yapıla methodun türü
                RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/series/"), //istek yapılan adres
                Headers =
    {
        { "X-RapidAPI-Key", "165cdd06e5mshb82ebf450dce236p1c3102jsn978ea6bd7f6c" },
        { "X-RapidAPI-Host", "imdb-top-100-movies.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode(); //isteğin başarılı bir şekilde gerçekleşip gerçekleşmediğni dair bize geri dönen bir durum kodudur 
                var body = await response.Content.ReadAsStringAsync(); //içeriği okuyor
                var value = JsonConvert.DeserializeObject<List<ImdbSeriosViewModel>>(body);
                //Json dedikten sonra Newtonsoft.Json seçiyoruz
                //Deserialize->
                return View(value);
            }
        }
    }
}
#region Serialize
//Serialize(Serileştirme)
//Serialize, bir C# nesnesini belirli bir formatta (örneğin JSON veya XML) bir veri akışına dönüştürme işlemidir. Bu, verilerin dosya sistemine kaydedilmesi, ağ üzerinden gönderilmesi veya başka bir programa aktarılması için kullanılır.
#endregion
#region Deserialize
//Deserialize(Deserileştirme)
//Deserialize, serileştirilmiş bir veri akışını (örneğin JSON veya XML) C# nesnesine geri dönüştürme işlemidir. Bu, verilerin yeniden işlenebilmesi veya kullanılabilmesi için gereklidir.
#endregion
