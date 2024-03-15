using Microsoft.Extensions.DependencyInjection;
using WhatsApp.Core.Factory;
using WhatsApp.Core.Factory.UltraMsg;
using WhatsApp.Services;
using WhatsApp.Services.UltraMSG;

namespace WhatsApp
{
    public static class WhatsAppStartup
    {
        public static void StartupServices(this IServiceCollection services)
        {
            services.AddTransient<IWhatsAppFactory, UltraMsgFactory>();
            services.AddTransient<IWhatsAppService, WhatsAppService<UltraMsgFactory>>();
            services.AddTransient<IUltraMsgService, UltraMsgService>();

        }
    }
}
