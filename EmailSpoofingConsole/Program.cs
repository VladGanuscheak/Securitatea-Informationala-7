using EmailSpoofingConsole.Spoofing;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Threading.Tasks;

namespace EmailSpoofingConsole
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            //await CreateWebHostBuilder(args).Build().RunAsync();

            Console.WriteLine("Enter recepient");
            var recepient = Console.ReadLine();

            Console.WriteLine("Enter subject");
            var subject = Console.ReadLine();

            Console.WriteLine("Enter the content");
            var content = Console.ReadLine();

            var spoofing = new EmailSpoofing();
            await spoofing.SendMessageAsync(recepient, subject, content);

            Console.WriteLine($"You may close the console...");
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
