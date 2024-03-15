using RestSharp;


namespace WhatsApp.Models
{
    public class RequestModel
    {
        public RestClient Client { get; set; } = new();
        public RestRequest Request { get; set; } = new();
    }
}
