using EncryptorSync.Encryptor.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace EncryptorSync.Encryptor
{
    public class Encryptor : IEncryptor
    {
        #region Properties
        public int P { get; set; }
        public int Q { get; set; }
        public int Diapason { get; set; }
        
        #endregion

        #region Private methods
        private string Encrypt(int n)
        {
            if (n == 0) return string.Empty;
            return Encrypt((n - 1) / Diapason) + (char)((n - 1) % Diapason + '0');
        }

        private int Decryptor(string encryptedMessage)
        {
            var result = 0;
            for(int i = 0; i < encryptedMessage.Length - 1; i++)
            {
                result = (result + (int)(encryptedMessage[i] - '0') + 1) * Diapason;
            }
            result = result + (int)(encryptedMessage[encryptedMessage.Length - 1] - '0') + 1;
            return (result - Q) / P;
        }
        #endregion

        #region Actions
        private async Task<string> EncodeMessageAsync(string message)
        {
            return await Task<string>.Run(() =>
            {
                var result = new StringBuilder();
                foreach (byte item in message)
                {
                    var value = (int)(item);
                    result.Append($"{Encrypt(value * P + Q).Trim('\0')}&");
                }
                result.Append('\0');
                return result.ToString();
            });   
        }

        private async Task<string> EncodeMessageFromFileAsync(string filename)
        {
            try
            {
                var content = await GetFileContentAsync(filename);
                P = Int32.Parse(content.Split()[0]);
                Q = Int32.Parse(content.Split()[1]);
                Diapason = Int32.Parse(content.Split()[2]);
                return await EncodeMessageAsync(content.Split('\n')[1]);
            }
            catch(Exception exception)
            {
                Debug.WriteLine($"{(exception.GetType()).ToString()}: {exception.Message}");
            }

            return string.Empty;
        }

        private async Task<string> DecodeMessageAsync(string message)
        {
            var result = new StringBuilder();

            await Task.Run(() =>
            {
                var temporary = string.Empty;
                foreach(var item in message)
                {
                    if (item != '&')
                    {
                        temporary += item;
                    }
                    else
                    {
                        result.Append((char)(Decryptor(temporary.ToString())));
                        temporary = string.Empty;
                    }
                }
            });

            return result.ToString();
        }

        private async Task<string> DecodeMessageFromFileAsync(string filename)
        {
            try
            {
                var content = await GetFileContentAsync(filename);
                P = Int32.Parse(content.Split()[0]);
                Q = Int32.Parse(content.Split()[1]);
                Diapason = Int32.Parse(content.Split()[2]);
                return await DecodeMessageAsync(content.Split('\n')[1]);
            }
            catch (Exception exception)
            {
                Debug.WriteLine($"{(exception.GetType()).ToString()}: {exception.Message}");
            }

            return string.Empty;
        }
        #endregion

        public void Configure(int p, int q, int diapason)
        {
            P = p;
            Q = q;
            Diapason = diapason;
        }

        //public Encryptor Configure(Encryptor encryptor)
        //{
        //    P = encryptor.P;
        //    Q = encryptor.Q;
        //    Diapason = encryptor.Diapason;
        //    return encryptor;
        //}

        public async Task<string> DecryptAsync(string message)
        {
            return await DecodeMessageAsync(message);
        }

        public async Task<string> DecryptFromFileAsync(string filename)
        {
            return await DecodeMessageFromFileAsync(filename);
        }

        public async Task<string> EncryptAsync(string message)
        {
            return await EncodeMessageAsync(message);
        }

        public async Task<string> EncryptFromFileAsync(string filename)
        {
            return await EncodeMessageFromFileAsync(filename);
        }

        public async Task<string> GetFileContentAsync(string filename)
        {
            using (var fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    var content = await streamReader.ReadToEndAsync();
                    return content;
                }
            }
        }
    }
}
