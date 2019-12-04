namespace VinylRecordSale.Domain.IntegrationObjects
{
    public class ResponseTokenSpotify
    {
        public string access_token { get; set; }
        public string error { get; set; }
        public string error_description { get; set; }
    }
}