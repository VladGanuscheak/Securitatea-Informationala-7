using System.Threading.Tasks;

namespace FileManager.EncryptedMessages.Interfaces
{
    public interface IEncryptedFileMessages
    {
        Task<bool> CreateEncryptedFileAsync(string filename, string content);

        Task<bool> DecryptFileAsync(string filename, string content);
    }
}
