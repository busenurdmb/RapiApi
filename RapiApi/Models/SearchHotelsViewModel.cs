namespace RapiApi.Models
{
	public class SearchHotelsViewModel
	{

		public Result[] result { get; set; }

		public class Result
		{
			public Composite_Price_Breakdown? composite_price_breakdown { get; set; }
			public string? review_recommendation { get; set; }
			public Checkin? checkin { get; set; }
			public string? hotel_name_trans { get; set; }
			public float? hotel_include_breakfast { get; set; }
			public string? review_score_word { get; set; }
			public float? main_photo_id { get; set; }
			public string? distance_to_cc { get; set; }
			public float? is_no_prepayment_block { get; set; }
			public string unit_configuration_label { get; set; }
			public float? review_score { get; set; }
			public float? is_free_cancellable { get; set; }
			public string? max_photo_url { get; set; }
			public string? url { get; set; }
			public string? city { get; set; }
			public string? ribbon_text { get; set; }
		}

		public class Composite_Price_Breakdown
		{
			public All_Inclusive_Amount? all_inclusive_amount { get; set; }
		}

		public class All_Inclusive_Amount
		{
			public string? amount_rounded { get; set; }
			public string? currency { get; set; }
			public float? value { get; set; }
			public string? amount_unrounded { get; set; }
		}


		public class Checkout
		{
			public string? from { get; set; }
			public string? until { get; set; }
		}

		public class Checkin
		{
			public string? from { get; set; }
			public string? until { get; set; }
		}

	}
}
























