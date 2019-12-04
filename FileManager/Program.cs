using FileManager.EncryptedMessages;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Threading.Tasks;

namespace FileManager
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            //await CreateWebHostBuilder(args).Build().RunAsync();

            Console.WriteLine("Enter filename");
            var filename = Console.ReadLine();
            Console.WriteLine($"Creating the file {filename}");

            Console.WriteLine("Enter the content");
            var content = Console.ReadLine();

            var file = new EncryptedFileMessages();
            await file.CreateEncryptedFileAsync(filename, content);

            Console.WriteLine($"The file has been created!!!");
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
