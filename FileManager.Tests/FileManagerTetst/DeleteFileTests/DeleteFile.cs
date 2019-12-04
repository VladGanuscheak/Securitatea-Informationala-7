using FileManager.SystemFileManager.Interfaces;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace FileManager.Tests.FileManagerTetst.DeleteFileTests
{
    public class DeleteFile
    {
        private readonly IFileManager _fileManager;
        private readonly string directory;

        public DeleteFile()
        {
            _fileManager = new FileManager.SystemFileManager.FileManager();
            directory = $"{Directory.GetCurrentDirectory().Split($"\\FileManager")[0]}\\FileManager.Tests\\FileManagerTetst\\DeleteFileTests";
        }

        [Fact]
        public async Task DeleteFile_ValidFile_True()
        {
            // Arrange
            var filename = $"{directory}\\{nameof(this.DeleteFile_ValidFile_True)}.txt";
            var content = "Test content.";

            // Act
            var createFileResult = await _fileManager.CreateFileFromContent(filename, content);
            var deleteFileResult = await _fileManager.DeleteFile(filename);

            // Assert
            Assert.True(createFileResult);
            Assert.True(deleteFileResult);
        }

        [Fact]
        public async Task DeleteFile_UnexistingFile_True()
        {
            // Arrange
            var filename = $"{directory}\\{nameof(this.DeleteFile_UnexistingFile_True)}.txt";

            // Act
            var result = await _fileManager.DeleteFile(filename);

            // Assert
            Assert.True(result);
        }
    }
}
