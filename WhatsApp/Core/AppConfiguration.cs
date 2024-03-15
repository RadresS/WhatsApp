using Microsoft.Extensions.Configuration;
using WhatsApp.Models;
namespace WhatsApp.Core
{
    public class AppConfiguration
    {
        public readonly string _InstanceId = string.Empty;
        public readonly string _Token = string.Empty;
        public readonly string _Mobile = string.Empty;
        public readonly string _ApiUrl = string.Empty;


        public AppConfiguration(CompanyName companyName)
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "WhatsApp.json");
            configurationBuilder.AddJsonFile(path, false);

            var root = configurationBuilder.Build();
            _InstanceId = root.GetSection("InstanceId").GetSection(companyName.ToString()).Value;
            _Token = root.GetSection("Token").GetSection(companyName.ToString()).Value;
            _Mobile = root.GetSection("Mobile").GetSection(companyName.ToString()).Value;
            _ApiUrl = root.GetSection("Api").GetSection(companyName.ToString()).Value;

            //_ = root.GetSection("ApplicationSettings");
        }
        public string InstanceId { get => _InstanceId; }
        public string Token { get => _Token; }
        public string Mobile { get => _Mobile; }
        public string ApiUrl { get => _ApiUrl; }

    }
}
