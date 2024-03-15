using RestSharp;
using WhatsApp.Models;
using WhatsApp.Services;

namespace WhatsApp.Extensions
{
    public static class UltraMsgExtension
    {
        public static string GetContent(this RestResponse response)
        {
            return response.Content;
        }
        public static async Task<RestResponse> Send(this IWhatsAppService service, string message, string Phone, MessageType messageType, string file = null)
        {
            return await service.Create(messageType, file: file, message: message, Phone: Phone);
        }

    }
}
