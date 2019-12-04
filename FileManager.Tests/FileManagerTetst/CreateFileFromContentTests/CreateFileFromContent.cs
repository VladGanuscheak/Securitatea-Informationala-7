using FileManager.SystemFileManager.Interfaces;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace FileManager.Tests.FileManagerTetst.CreateFileFromContentTests
{
    public class CreateFileFromContent
    {
        private readonly IFileManager _fileManager;
        private readonly string directory;

        public CreateFileFromContent()
        {
            _fileManager = new FileManager.SystemFileManager.FileManager();
            directory = $"{Directory.GetCurrentDirectory().Split($"\\FileManager")[0]}\\FileManager.Tests\\FileManagerTetst\\CreateFileFromContentTests";
        }

        [Fact]
        public async Task CreateFileFromContent_NullContent_True()
        {
            // Arrange
            var filename = $"{directory}\\{nameof(this.CreateFileFromContent_NullContent_True)}.txt";

            // Act
            var result = await _fileManager.CreateFileFromContent(filename, null);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task CreateFileFromContent_EmptyContent_True()
        {
            // Arrange
            var filename = $"{directory}\\{nameof(this.CreateFileFromContent_EmptyContent_True)}.txt";
            var content = string.Empty;

            // Act
            var result = await _fileManager.CreateFileFromContent(filename, content);

            // Assert
            Assert.True(result);
        }
    }
}
