using RestSharp;
using WhatsApp.Models;

namespace WhatsApp.Services
{
    public interface IWhatsAppService
    {
        Setting? setting { get; set; }
        Task<RestResponse> Create(MessageType messageType, RequestModel request = null, string file = null, string message = null, string Phone = null, string caption = null, string fileName = null);
        string GetApiUrl(MessageType messageType);
        RequestModel AddParameter(MessageType messageType, RequestModel request = null, string file = null, string message = null, string caption = null, string fileName = null);
    }
}
