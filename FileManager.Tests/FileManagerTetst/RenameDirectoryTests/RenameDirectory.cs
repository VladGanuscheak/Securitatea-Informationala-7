using FileManager.SystemFileManager.Interfaces;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace FileManager.Tests.FileManagerTetst.RenameDirectoryTests
{
    public class RenameDirectory
    {
        private readonly IFileManager _fileManager;
        private readonly string directory;

        public RenameDirectory()
        {
            _fileManager = new FileManager.SystemFileManager.FileManager();
            directory = $"{Directory.GetCurrentDirectory().Split($"\\FileManager")[0]}\\FileManager.Tests\\FileManagerTetst\\RenameDirectoryTests";
        }

        [Fact]
        public async Task RenameDirectory_ExistingDirectory_True()
        {
            // Arrange
            var directoryName = $"{directory}\\{nameof(this.RenameDirectory_ExistingDirectory_True)}";

            // Act
            var createDirectoryResult = await _fileManager.CreateDirectory(directoryName);
            var renameDirectoryResult = await _fileManager.RenameDirectory(directoryName, $"{directoryName}_new");
            var deleteCreatedDirectory = await _fileManager.DeleteDirectory($"{directoryName}_new");

            // Assert
            Assert.True(createDirectoryResult);
            Assert.True(renameDirectoryResult);
            Assert.True(deleteCreatedDirectory);
        }

        [Fact]
        public async Task RenameDirectory_NonExistingDirectory_False()
        {
            // Arrange
            var directoryName = $"{directory}\\{nameof(this.RenameDirectory_ExistingDirectory_True)}_fake";

            // Act
            var result = await _fileManager.RenameDirectory(directoryName, $"{directoryName}Double");

            // Assert
            Assert.False(result);
        }
    }
}
