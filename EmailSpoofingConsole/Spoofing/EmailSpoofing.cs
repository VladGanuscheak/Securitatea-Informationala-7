using System.Threading.Tasks;
using EmailSpoofingConsole.Spoofing.Interfaces;

namespace EmailSpoofingConsole.Spoofing
{
    public class EmailSpoofing : ISpoofing
    {
        public Task SendMessageAsync(string recepient, string Subject, string Body)
        {
            throw new System.NotImplementedException();
        }
    }
}
