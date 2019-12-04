using FileManager.SystemFileManager.Interfaces;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace FileManager.Tests.FileManagerTetst.GetFileInfoTests
{
    public class GetFileInfo
    {
        private readonly IFileManager _fileManager;
        private readonly string directory;

        public GetFileInfo()
        {
            _fileManager = new FileManager.SystemFileManager.FileManager();
            directory = $"{Directory.GetCurrentDirectory().Split($"\\FileManager")[0]}\\FileManager.Tests\\FileManagerTetst\\GetFileInfoTests";
        }

        [Fact]
        public async Task GetFileInfo_CurrentFile_NotNullExists()
        {
            // Arrange
            var currentFile = $"{directory}\\{this.GetType().Name}.cs";

            // Act
            var result = await _fileManager.GetFileInfo(currentFile);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Exists);
        }

        [Fact]
        public async Task GetFileInfo_InvalidFile_NullOrNonExistent()
        {
            // Arrange
            var fileName = $"{directory}\\{nameof(this.GetFileInfo_InvalidFile_NullOrNonExistent)}.txt";

            // Act
            var result = await _fileManager.GetFileInfo(fileName);

            // Assert
            Assert.True(result == null || !result.Exists);
        }
    }
}
