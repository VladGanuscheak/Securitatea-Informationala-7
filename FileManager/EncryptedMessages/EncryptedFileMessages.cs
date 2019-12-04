using System;
using System.Threading.Tasks;
using EncryptorSync.Encryptor.Interfaces;
using FileManager.EncryptedMessages.Interfaces;
using FileManager.SystemFileManager.Interfaces;

namespace FileManager.EncryptedMessages
{
    public class EncryptedFileMessages : IEncryptedFileMessages
    {
        private readonly IEncryptor _encryptor;
        private readonly IFileManager _fileManager;

        public EncryptedFileMessages()
        {
            var random = new Random();
            _encryptor = new EncryptorSync.Encryptor.Encryptor();
            _encryptor.Configure(random.Next(1, 10), random.Next(1, 20), random.Next(2, 38));

            _fileManager = new FileManager.SystemFileManager.FileManager();
        }

        public async Task<bool> CreateEncryptedFileAsync(string filename, string content)
        {
            return await _fileManager.CreateFileFromContent(filename, $"{_encryptor.P} {_encryptor.Q} {_encryptor.Diapason}\r\n{await _encryptor.EncryptAsync(content)}");
        }

        public async Task<bool> DecryptFileAsync(string filename, string content)
        {
            return await _fileManager.CreateFileFromContent(filename, await _encryptor.DecryptAsync(content));
        }
    }
}
