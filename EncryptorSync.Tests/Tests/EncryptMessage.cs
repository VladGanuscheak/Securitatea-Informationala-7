using EncryptorSync.Encryptor.Interfaces;
using System;
using System.Threading.Tasks;
using Xunit;

namespace EncryptorSync.Tests.Tests
{
    public class EncryptMessage
    {
        private readonly IEncryptor _encryptor;
        
        public EncryptMessage()
        {
            var random = new Random();
            _encryptor = new EncryptorSync.Encryptor.Encryptor();
            _encryptor.Configure(random.Next(1, 10), random.Next(1, 20), random.Next(2, 38));
        }

        [Fact]
        public async Task EncryptMessage_InitialMessage_EncodedMessageTrue()
        {
            // Arrange
            var message = "This message will be encrypted!";

            // Action
            var result = await _encryptor.EncryptAsync(message);

            // Asset
            Assert.NotEqual(message, result);
        }
    }
}
