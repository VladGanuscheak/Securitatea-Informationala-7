using FileManager.SystemFileManager.Interfaces;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace FileManager.Tests.FileManagerTetst.CreateDirectoryTests
{
    public class CreateDirectory
    {
        private readonly IFileManager _fileManager;
        private readonly string directory;

        public CreateDirectory()
        {
            _fileManager = new FileManager.SystemFileManager.FileManager();
            directory = $"{Directory.GetCurrentDirectory().Split($"\\FileManager")[0]}\\FileManager.Tests\\FileManagerTetst\\CreateDirectoryTests";
        }

        [Fact]
        public async Task CreateDirectory_NewDirectory_True()
        {
            // Arrange
            var directoryName = $"{directory}\\{nameof(this.CreateDirectory_NewDirectory_True)}";

            // Act
            var result = await _fileManager.CreateDirectory(directoryName);

            // Assert
            Assert.True(result);
        }
    }
}
