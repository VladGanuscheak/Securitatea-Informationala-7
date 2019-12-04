using FileManager.SystemFileManager.Interfaces;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace FileManager.Tests.FileManagerTetst.AppendContentToFileTests
{
    public class AppendContentToFile
    {
        private readonly IFileManager _fileManager;
        private readonly string directory;

        public AppendContentToFile()
        {
            _fileManager = new FileManager.SystemFileManager.FileManager();
            directory = $"{Directory.GetCurrentDirectory().Split($"\\FileManager")[0]}\\FileManager.Tests\\FileManagerTetst\\AppendContentToFileTests";
        }

        [Fact]
        public async Task AppendContentToFile_ThereIsNoFile_True()
        {
            // Arrange
            var filename = $"{directory}\\{nameof(this.AppendContentToFile_ThereIsNoFile_True)}.txt";
            var content = "Simple test text!";

            // Act
            var result = await _fileManager.AppendContentToFile(filename, content);
            var deleteResult = await _fileManager.DeleteFile(filename);

            // Assert
            Assert.True(result);
            Assert.True(deleteResult);
        }

        [Fact]
        public async Task AppendContentToFile_NullContent_True()
        {
            // Arrange
            var filename = $"{directory}\\{nameof(this.AppendContentToFile_NullContent_True)}.txt";

            // Act
            var result = await _fileManager.AppendContentToFile(filename, null);
            var deleteResult = await _fileManager.DeleteFile(filename);

            // Assert
            Assert.True(result);
            Assert.True(deleteResult);
        }

        [Fact]
        public async Task AppendContentToFile_FileExistsContentValid_True()
        {
            // Arrange
            var filename = $"{directory}\\{nameof(this.AppendContentToFile_FileExistsContentValid_True)}.txt";
            var content = "Valid content for test...";

            // Act
            var deleteFileResult = await _fileManager.DeleteFile(filename);
            var createFileResult = await _fileManager.CreateFileFromContent(filename, "Something...");
            var result = await _fileManager.AppendContentToFile(filename, content);

            // Assert
            Assert.True(deleteFileResult);
            Assert.True(createFileResult);
            Assert.True(result);
        }

        [Fact]
        public async Task AppendContentToFile_FileExistsEmptyContent_True()
        {
            // Arrange
            var filename = $"{directory}\\{nameof(this.AppendContentToFile_FileExistsEmptyContent_True)}.txt";
            var content = string.Empty;

            // Act
            var deleteFileResult = await _fileManager.DeleteFile(filename);
            var createFileResult = await _fileManager.CreateFileFromContent(filename, content);
            var result = await _fileManager.AppendContentToFile(filename, content);

            // Assert
            Assert.True(deleteFileResult);
            Assert.True(createFileResult);
            Assert.True(result);
        }
    }
}
