using System.Threading.Tasks;

namespace EmailSpoofingConsole.Spoofing.Interfaces
{
    public interface ISpoofing
    {
        Task SendMessageAsync(string recepient, string Subject, string Body);
    }
}
