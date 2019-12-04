using EncryptorSync.Encryptor.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EncryptorSync.Tests.Tests
{
    public class EncryptMessageFromFile
    {
        private readonly IEncryptor _encryptor;
        private readonly string directory;

        public EncryptMessageFromFile()
        {
            var random = new Random();
            _encryptor = new EncryptorSync.Encryptor.Encryptor();
            _encryptor.Configure(random.Next(1, 10), random.Next(1, 20), random.Next(2, 38));
            directory = $"{Directory.GetCurrentDirectory().Split($"\\EncryptorSync")[0]}\\EncryptorSync.Tests\\Tests\\Files";
        }

        [Fact]
        public async Task EncryptMessageFromFile_InitialMessage_EncodedMessageTrue()
        {
            // Arrange
            var initialMessage = "Hello, my friend!!!";
            var filename = $"{directory}\\encrypted_message.txt";

            // Action
            var decryptedMessage = await _encryptor.DecryptFromFileAsync(filename);

            // Asset
            Assert.Equal(initialMessage, decryptedMessage);
        }
    }
}
