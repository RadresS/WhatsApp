using RestSharp;
using WhatsApp.Core.Factory;
using WhatsApp.Models;

namespace WhatsApp.Services
{
    public class WhatsAppService<Options> : IWhatsAppService where Options : IWhatsAppFactory, new()
    {
        public Setting? setting { get; set; } = new();

        public async Task<RestResponse> Create(MessageType messageType, RequestModel request = null, string file = null, string message = null, string Phone = null, string caption = null, string fileName = null)
        {
            setting = new Options().Set();
            if (request == null)
                request = new RequestModel();

            var url = GetApiUrl(MessageType.Text);
            setting.Url = url;
            request.Client = new RestClient(setting.Url);
            request.Request = new RestRequest(setting.Url, Method.Post);
            request.Request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.Request.AddParameter("token", setting.Token);
            request.Request.AddParameter("to", Phone ?? setting.Mobile);
            request = AddParameter(messageType, request, file: file, message: message);
            return await request.Client.ExecuteAsync(request.Request);
        }

        public string GetApiUrl(MessageType messageType)
        {
            setting = new Options().Set();
            switch (messageType)
            {
                case MessageType.Text:
                    return setting.ApiUrl + setting.InstanceId + "/messages/chat";
                case MessageType.Image:
                    return setting.ApiUrl + setting.InstanceId + "/messages/image";
                case MessageType.Document:
                    return setting.ApiUrl + setting.InstanceId + "/messages/document";
                case MessageType.Audio:
                    return setting.ApiUrl + setting.InstanceId + "/messages/audio";
                case MessageType.Voice:
                    return setting.ApiUrl + setting.InstanceId + "/messages/voice";
                case MessageType.Video:
                    return setting.ApiUrl + setting.InstanceId + "/messages/video";
                case MessageType.Link:
                    return setting.ApiUrl + setting.InstanceId + "/messages/link";
                case MessageType.Contact:
                    return setting.ApiUrl + setting.InstanceId + "/messages/contact";
                case MessageType.Location:
                    return setting.ApiUrl + setting.InstanceId + "/messages/location";
                case MessageType.VCard:
                    return setting.ApiUrl + setting.InstanceId + "/messages/vcard";
                default:
                    return setting.ApiUrl + setting.InstanceId + "/messages/chat";
            }
        }
        public RequestModel AddParameter(MessageType messageType, RequestModel request = null, string file = null, string message = null, string caption = null, string fileName = null)
        {
            switch (messageType)
            {
                case MessageType.Text:
                    request.Request.AddParameter("body", @message);
                    break;
                case MessageType.Image:
                    request.Request.AddParameter("image", @file);
                    request.Request.AddParameter("caption", @caption);
                    break;
                case MessageType.Document:
                    request.Request.AddParameter("document", @file);
                    request.Request.AddParameter("filename", @fileName);
                    break;
                case MessageType.Audio:
                    request.Request.AddParameter("audio", @file);
                    break;
                case MessageType.Voice:
                    request.Request.AddParameter("audio", @file);
                    break;
                case MessageType.Video:
                    request.Request.AddParameter("video", @file);
                    break;
                case MessageType.Link:
                    request.Request.AddParameter("link", @file);
                    break;
                case MessageType.Contact:
                    request.Request.AddParameter("contact", @file);
                    break;
                case MessageType.Location:
                    request.Request.AddParameter("address", @file);
                    break;
                case MessageType.VCard:
                    request.Request.AddParameter("vcard", @file);
                    break;
                default:
                    request.Request.AddParameter("body", @message);
                    break;
            }
            return request;
        }

    }
}
