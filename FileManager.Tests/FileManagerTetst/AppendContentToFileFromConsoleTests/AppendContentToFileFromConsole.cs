using FileManager.SystemFileManager.Interfaces;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace FileManager.Tests.FileManagerTetst.AppendContentToFileFromConsoleTests
{
    public class AppendContentToFileFromConsole
    {
        private readonly IFileManager _fileManager;
        private readonly string directory;

        public AppendContentToFileFromConsole()
        {
            _fileManager = new FileManager.SystemFileManager.FileManager();
            directory = $"{Directory.GetCurrentDirectory().Split($"\\FileManager")[0]}\\FileManager.Tests\\FileManagerTetst\\AppendContentToFileFromConsoleTests";
        }

        [Fact]
        public async Task AppendContentToFileFromConsole_FileExists_True()
        {

            //// Arrange
            //var filename = $"{directory}\\test.txt";

            //// Act
            //var oldLength = (new FileInfo(filename)).Length;
            //var response = await _fileManager.AppendContentToFileFromConsole(filename);
            //var newLength = (new FileInfo(filename)).Length;

            //// Assert
            //Assert.NotEqual(oldLength, newLength);
            //Assert.True(response);
        }

        [Fact]
        public async Task AppendContentToFileFromConsole_FileNotExists_False()
        {
            //// Arrange
            //var filename = $"{directory}\\wrongname.txt";

            //// Act
            //var response = await _fileManager.AppendContentToFileFromConsole(filename);
            
            //// Assert
            //Assert.True(response);
        }
    }
}
