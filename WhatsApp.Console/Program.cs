using Microsoft.Extensions.DependencyInjection;
using WhatsApp;
using WhatsApp.Extensions;
using WhatsApp.Services.UltraMSG;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
var services = new ServiceCollection();
services.StartupServices();
var srv = services.BuildServiceProvider();

var whatsApp = srv.GetService<IUltraMsgService>();
Console.Write("Lütfen bir telefon numarası giriniz : ");
var phone = Console.ReadLine();
Console.Write("Mesajınızı Yazını : ");
var mesaj = Console.ReadLine();
Console.Write("1 Gönder 2 Iptal : ");
var durum = Console.ReadLine();
if (durum == "1")
{
    var msg = await whatsApp.Send(mesaj, phone, WhatsApp.Models.MessageType.Text);
    Console.WriteLine(msg.GetContent());

}
