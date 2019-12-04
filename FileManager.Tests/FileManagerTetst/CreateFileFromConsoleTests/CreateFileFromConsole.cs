using FileManager.SystemFileManager.Interfaces;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace FileManager.Tests.FileManagerTetst.CreateFileFromConsoleTests
{
    public class CreateFileFromConsole
    {
        private readonly IFileManager _fileManager;
        private readonly string directory;

        public CreateFileFromConsole()
        {
            _fileManager = new FileManager.SystemFileManager.FileManager();
            directory = $"{Directory.GetCurrentDirectory().Split($"\\FileManager")[0]}\\FileManager.Tests\\FileManagerTetst\\CreateFileFromConsoleTests";
        }

        [Fact]
        public async Task CreateFileFromConsole_ValidFile_True()
        {
            //// Arrange
            //var filename = $"{nameof(this.CreateFileFromConsole_ValidFile_True)}.txt";

            //// Act
            //var result = await _fileManager.CreateFileFromConsole(filename);

            //// Assert
            //Assert.True(result);
        }
    }
}
