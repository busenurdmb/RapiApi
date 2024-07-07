using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NuGet.Versioning;
using RapiApi.Models;

namespace RapiApi.Controllers
{
    public class BookingController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com.p.rapidapi.com/v1/hotels/search?checkout_date=2024-09-15&order_by=popularity&filter_by_currency=AED&include_adjacency=true&children_number=2&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1&room_number=1&dest_id=-553173&dest_type=city&adults_number=2&page_number=0&checkin_date=2024-09-14&locale=en-gb&units=metric&children_ages=5%2C0"),
                Headers =
    {
        { "x-rapidapi-key", "165cdd06e5mshb82ebf450dce236p1c3102jsn978ea6bd7f6c" },
        { "x-rapidapi-host", "booking-com.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
				var value1 = JsonConvert.DeserializeObject<SearchHotelsViewModel>(body);
				return View(value1.result.ToList());

			}
            
        }
        [HttpPost]
        public async Task<IActionResult> Index(HotelSearchRequest model)
        {
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/locations?name={model.city}&locale=en-gb"),
				Headers =
	{
		{ "x-rapidapi-key", "165cdd06e5mshb82ebf450dce236p1c3102jsn978ea6bd7f6c" },
		{ "x-rapidapi-host", "booking-com.p.rapidapi.com" },
	},
			};
			using (var response = await client.SendAsync(request))
			{
				response.EnsureSuccessStatusCode();
				var body = await response.Content.ReadAsStringAsync();
				var value = JsonConvert.DeserializeObject<List<HotelSearchLocationViewModel>>(body);
				var destinationıd = value[0].dest_id;

				var client1 = new HttpClient();
				var request1 = new HttpRequestMessage
				{
					Method = HttpMethod.Get,
					RequestUri = new Uri($"https://booking-com.p.rapidapi.com/v1/hotels/search?checkout_date={model.CheckoutDate:yyyy-MM-dd}&order_by=popularity&filter_by_currency=AED&include_adjacency=true&children_number={model.ChildrenNumber}&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1&room_number=1&dest_id={destinationıd}&dest_type=city&adults_number={model.AdultsNumber}&page_number=0&checkin_date={model.CheckinDate:yyyy-MM-dd}&locale=en-gb&units=metric&children_ages=5%2C0"),
					Headers =
	{
		{ "x-rapidapi-key", "165cdd06e5mshb82ebf450dce236p1c3102jsn978ea6bd7f6c" },
		{ "x-rapidapi-host", "booking-com.p.rapidapi.com" },
	},
				};
				using (var response1 = await client1.SendAsync(request1))
				{
					response1.EnsureSuccessStatusCode();
					var body1 = await response1.Content.ReadAsStringAsync();
					var value1 = JsonConvert.DeserializeObject<SearchHotelsViewModel>(body1);
					return View(value1.result.ToList());
					
				}

			}
		
          
           
        }
       
    }
}
