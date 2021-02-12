namespace LeakerUtility.Constants
{
    class FortniteAPI
	{
		/// <summary>
		/// The base API URL for Fortnite-API v1.
		/// </summary>
		public static string V1_BASE_URL => "https://fortnite-api.com/v1";

		/// <summary>
		/// The base API URL for Fortnite-API v2.
		/// </summary>
		public static string V2_BASE_URL => "https://fortnite-api.com/v2";

		/// <summary>
		/// The BR News endpoint for Fortnite-API.
		/// </summary>
		public static string BR_NEWS_ENDPOINT => $"{V2_BASE_URL}/news/br";

		/// <summary>
		/// The New Cosmetics endpoint for Fortnite-API.
		/// </summary>
		public static string NEW_COSMETICS_ENDPOINT => $"{V2_BASE_URL}/cosmetics/br/new";

		/// <summary>
		/// The Map endpoint for Fortnite-API.
		/// </summary>
		public static string MAP_ENDPOINT => $"{V1_BASE_URL}/map";

		/// <summary>
		/// The AES endpoint for Fortnite-API.
		/// </summary>
		public static string AES_ENDPOINT => $"{V2_BASE_URL}/aes";
	}
}