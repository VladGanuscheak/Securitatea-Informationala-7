using FileManager.SystemFileManager.Interfaces;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace FileManager.Tests.FileManagerTetst.GetDirectoryInfoTests
{
    public class GetDirectoryInfo
    {
        private readonly IFileManager _fileManager;
        private readonly string directory;

        public GetDirectoryInfo()
        {
            _fileManager = new FileManager.SystemFileManager.FileManager();
            directory = $"{Directory.GetCurrentDirectory().Split($"\\FileManager")[0]}\\FileManager.Tests\\FileManagerTetst\\GetDirectoryInfoTests";
        }

        [Fact]
        public async Task GetDirectoryInfo_CurrentDirectory_NotNullExists()
        {
            // Arrange
            var currentDirectory = directory;

            // Act
            var result = await _fileManager.GetDirectoryInfo(currentDirectory);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Exists);
        }

        [Fact]
        public async Task GetDirectoryInfo_InvalidDirectory_NullOrNotExistened()
        {
            // Arrange
            var invalidDirectory = $"{directory}\\{nameof(this.GetDirectoryInfo_InvalidDirectory_NullOrNotExistened)}";

            // Act
            var result = await _fileManager.GetDirectoryInfo(invalidDirectory);

            // Assert
            Assert.True(result == null || !result.Exists);
        }
    }
}
