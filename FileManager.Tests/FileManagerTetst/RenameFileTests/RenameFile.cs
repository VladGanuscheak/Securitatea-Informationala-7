using FileManager.SystemFileManager.Interfaces;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace FileManager.Tests.FileManagerTetst.RenameFileTests
{
    public class RenameFile
    {
        private readonly IFileManager _fileManager;
        private readonly string directory;

        public RenameFile()
        {
            _fileManager = new FileManager.SystemFileManager.FileManager();
            directory = $"{Directory.GetCurrentDirectory().Split($"\\FileManager")[0]}\\FileManager.Tests\\FileManagerTetst\\RenameFileTests";
        }

        [Fact]
        public async Task RenameFile_FileExists_True()
        {
            // Arrange
            var filename = $"{directory}\\{nameof(this.RenameFile_FileExists_True)}.txt";
            var content = "Something...";

            // Act
            var createResult = await _fileManager.CreateFileFromContent(filename, content);
            var result = await _fileManager.RenameFile(filename, $"{filename}_new");
            var deleteRenamedResult = await _fileManager.DeleteFile($"{filename}_new");

            // Assert
            Assert.True(createResult);
            Assert.True(result);
            Assert.True(deleteRenamedResult);
        }

        [Fact]
        public async Task RenameFile_NonExistingFile_False()
        {
            // Arrange
            var filename = $"{directory}\\{nameof(this.RenameFile_NonExistingFile_False)}.txt";

            // Act
            var result = await _fileManager.RenameFile(filename, $"{filename}_wrong");

            // Assert
            Assert.False(result);
        }
    }
}
