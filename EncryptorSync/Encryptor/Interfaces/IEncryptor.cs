using System.Threading.Tasks;

namespace EncryptorSync.Encryptor.Interfaces
{
    public interface IEncryptor
    {
        #region Properties
        int P { get; set; }

        int Q { get; set; }
        
        int Diapason { get; set; }
        #endregion

        void Configure(int p, int q, int diapason);

        Task<string> EncryptAsync(string message);

        Task<string> EncryptFromFileAsync(string filenam);

        Task<string> DecryptAsync(string message);

        Task<string> DecryptFromFileAsync(string filename);

        Task<string> GetFileContentAsync(string filename);
    }
}
