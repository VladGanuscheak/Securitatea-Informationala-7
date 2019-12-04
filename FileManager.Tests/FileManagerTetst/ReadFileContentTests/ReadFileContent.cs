using FileManager.SystemFileManager.Interfaces;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace FileManager.Tests.FileManagerTetst.ReadFileContentTests
{
    public class ReadFileContent
    {
        private readonly IFileManager _fileManager;
        private readonly string directory;

        public ReadFileContent()
        {
            _fileManager = new FileManager.SystemFileManager.FileManager();
            directory = $"{Directory.GetCurrentDirectory().Split($"\\FileManager")[0]}\\FileManager.Tests\\FileManagerTetst\\ReadFileContentTests";
        }

        [Fact]
        public async Task ReadFileContent_FromExistingFile_True()
        {
            // Arrange
            var filename = $"{directory}\\{nameof(this.ReadFileContent_FromExistingFile_True)}.txt";
            var testContent = "This is the test content ;)";

            // Act
            var deleteFileResult = await _fileManager.DeleteFile(filename);
            var createFileResult = await _fileManager.CreateFileFromContent(filename, testContent);
            var result = await _fileManager.ReadFileContent(filename);

            // Assert
            Assert.True(deleteFileResult);
            Assert.True(createFileResult);
            Assert.Equal(testContent, result);
        }

        [Fact]
        public async Task ReadFileContent_FromNonExistingFile_Null()
        {
            // Arrange
            var filename = $"{directory}\\{nameof(this.ReadFileContent_FromNonExistingFile_Null)}.txt";

            // Act
            var result = await _fileManager.ReadFileContent(filename);

            // Assert
            Assert.Null(result);
        }
    }
}
