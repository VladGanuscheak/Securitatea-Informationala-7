using FileManager.SystemFileManager.Interfaces;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace FileManager.Tests.FileManagerTetst.DeleteDirectoryTests
{
    public class DeleteDirectory
    {
        private readonly IFileManager _fileManager;
        private readonly string directory;

        public DeleteDirectory()
        {
            _fileManager = new FileManager.SystemFileManager.FileManager();
            directory = $"{Directory.GetCurrentDirectory().Split($"\\FileManager")[0]}\\FileManager.Tests\\FileManagerTetst\\DeleteDirectoryTests";
        }

        [Fact]
        public async Task DeleteDirectory_ExistingDirectory_True()
        {
            // Arrange
            var directoryName = $"{directory}\\{nameof(this.DeleteDirectory_ExistingDirectory_True)}";

            // Act
            var createResult = await _fileManager.CreateDirectory(directoryName); 
            var deleteResult = await _fileManager.DeleteDirectory(directoryName, false);

            // Assert
            Assert.True(createResult);
            Assert.True(deleteResult);
        }

        [Fact]
        public async Task DeleteDirectory_NoSuchDirectory_True()
        {
            // Arrange
            var directoryName = $"{directory}\\{nameof(this.DeleteDirectory_NoSuchDirectory_True)}";

            // Act
            var result = await _fileManager.DeleteDirectory(directoryName);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task DeleteDirectory_NotEmptyDirectoryNoRecursion_False()
        {
            // Arrange
            var directoryName = $"{directory}\\{nameof(this.DeleteDirectory_NotEmptyDirectoryNoRecursion_False)}";

            // Act
            var createDirectoryResult = await _fileManager.CreateDirectory(directoryName);

            var filename = $"{directoryName}\\File.txt";
            var fileContent = "File inside the directory";
            var createFileInsideDirectoryResult = await _fileManager.CreateFileFromContent(filename, fileContent);
            
            var deleteResult = await _fileManager.DeleteDirectory(directoryName);

            // Assert
            Assert.True(createDirectoryResult);
            Assert.True(createFileInsideDirectoryResult);
            Assert.False(deleteResult);
        }

        [Fact]
        public async Task DeleteDirectory_NotEmptyDirectoryRecursion_True()
        {
            // Arrange
            var directoryName = $"{directory}\\{nameof(this.DeleteDirectory_NotEmptyDirectoryRecursion_True)}";

            // Act
            var createDirectoryResult = await _fileManager.CreateDirectory(directoryName);

            var filename = $"{directoryName}\\File.txt";
            var fileContent = "File inside the directory";
            var createFileInsideDirectoryResult = await _fileManager.CreateFileFromContent(filename, fileContent);

            var deleteResult = await _fileManager.DeleteDirectory(directoryName, true);

            // Assert
            Assert.True(createDirectoryResult);
            Assert.True(createFileInsideDirectoryResult);
            Assert.True(deleteResult);
        }
    }
}
