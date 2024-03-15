using WhatsApp.Models;

namespace WhatsApp.Core.Factory.UltraMsg
{
    public class UltraMsgFactory : IWhatsAppFactory
    {
        private readonly AppConfiguration appConfiguration;
        public UltraMsgFactory()
        {
            appConfiguration = new AppConfiguration(CompanyName.UltraMSG);
        }
        public Setting Set()
        {
            try
            {
                return new Setting
                {
                    ApiUrl = appConfiguration.ApiUrl,
                    InstanceId = appConfiguration.InstanceId,
                    Mobile = appConfiguration.Mobile,
                    Token = appConfiguration.Token,
                };

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return new Setting { ApiUrl = "", InstanceId = "", Mobile = "", Token = "", Url = "" };
            }
        }
    }
}
