using EncryptorSync.Encryptor.Interfaces;
using System;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace EncryptorSync.Tests.Tests
{
    public class DecryptMessageFromFile
    {
        private readonly IEncryptor _encryptor;
        private readonly string directory;

        public DecryptMessageFromFile()
        {
            var random = new Random();
            _encryptor = new EncryptorSync.Encryptor.Encryptor();
            _encryptor.Configure(random.Next(1, 10), random.Next(1, 20), random.Next(2, 38));
            directory = $"{Directory.GetCurrentDirectory().Split($"\\EncryptorSync")[0]}\\EncryptorSync.Tests\\Tests\\Files";
        }

        [Fact]
        public async Task DecryptMessageFromFile_File_True()
        {
            // Arrange
            var initialMessage = "Hello, my friend!!!";
            var filename = $"{directory}\\initial_message.txt";

            // Act
            var encryptedMessage = await _encryptor.EncryptFromFileAsync(filename);
            var decryptedMessage = await _encryptor.DecryptAsync(encryptedMessage);

            // Assert
            Assert.NotNull(encryptedMessage);
            Assert.Equal(initialMessage, decryptedMessage);
        }
    }
}
