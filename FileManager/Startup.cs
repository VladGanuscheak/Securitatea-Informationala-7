using EncryptorSync.Encryptor;
using EncryptorSync.Encryptor.Interfaces;
using FileManager.SystemFileManager.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace FileManager
{
    public class Startup
    {
         public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        [Obsolete]
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IEncryptor, Encryptor>();
            services.AddTransient<IFileManager, FileManager.SystemFileManager.FileManager>();
        }
    }
}
