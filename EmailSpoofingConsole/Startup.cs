using BackgroundScripts.Interfaces;
using EmailSpoofingConsole.Spoofing;
using EmailSpoofingConsole.Spoofing.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace EmailSpoofingConsole
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
            services.AddTransient<IBackgroundScripts, BackgroundScripts.BackgroundScripts>();
            services.AddTransient<ISpoofing, EmailSpoofing>();
        }
    }
}
