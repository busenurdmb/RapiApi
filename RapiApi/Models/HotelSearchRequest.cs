
namespace RapiApi.Models

{
    public class HotelSearchRequest
    {
		public DateTime CheckoutDate { get; set; }
		public string OrderBy { get; set; }
		public string Currency { get; set; }
		public string city { get; set; }
		public bool IncludeAdjacency { get; set; }
		public int ChildrenNumber { get; set; }
		public string CategoriesFilterIds { get; set; }
		public int RoomNumber { get; set; }
		public string DestId { get; set; }
		public string DestType { get; set; }
		public int AdultsNumber { get; set; }
		public int PageNumber { get; set; }
		public DateTime CheckinDate { get; set; }
		public string Locale { get; set; }
		public string Units { get; set; }
		public string ChildrenAges { get; set; }
	}

}
