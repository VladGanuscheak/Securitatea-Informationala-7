using System.Threading.Tasks;

namespace BackgroundScripts.Interfaces
{
    public interface IBackgroundScripts
    {
        Task BanDomain(string domainName);

        Task UnbanDomain(string domainName);

        Task SendEmailAnonymous();
    }
}
