using EncryptorSync.Encryptor.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EncryptorSync.Tests.Tests
{
    public class DecryptMessage
    {
        private readonly IEncryptor _encryptor;

        public DecryptMessage()
        {
            var random = new Random();
            _encryptor = new EncryptorSync.Encryptor.Encryptor();
            _encryptor.Configure(random.Next(1, 10), random.Next(1, 20), random.Next(2, 38));
        }

        [Fact]
        public async Task DecryptMessage_Encrypted_True()
        {
            // Arrange
            var initialMessage = "This is the initial message...";

            // Act
            var encodedMessage = await _encryptor.EncryptAsync(initialMessage);
            var decodedMessage = await _encryptor.DecryptAsync(encodedMessage);

            // Assert
            Assert.Equal(initialMessage, decodedMessage);
        }
    }
}
