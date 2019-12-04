using EncryptorSync.Encryptor;
using EncryptorSync.Encryptor.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Encryption.Models
{
    public class PasswordModel
    {
        private static IEncryptor _encryptor;
        private string _name;
        private string _password;

        public PasswordModel()
        {
            if (_encryptor == null)
            {
                var random = new Random();
                _encryptor = new EncryptorSync.Encryptor.Encryptor();
                _encryptor.Configure(random.Next(1, 10), random.Next(1, 20), random.Next(2, 38));
            }
        }

        public string Name
        {
            get => !string.IsNullOrEmpty(_name) ? _encryptor.DecryptAsync(_name).Result : _name;
            set { _name = _encryptor.EncryptAsync(value ?? string.Empty).Result; }
        }

        public string Password 
        {
            get => !string.IsNullOrEmpty(_password) ? _encryptor.DecryptAsync(_password ?? string.Empty).Result : _password;
            set { _password = _encryptor.EncryptAsync(value ?? string.Empty).Result; }
        }

        public string Domain { get; set; }
    }
}
