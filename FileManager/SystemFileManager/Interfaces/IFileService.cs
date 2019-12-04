using System.IO;
using System.Threading.Tasks;

namespace FileManager.SystemFileManager.Interfaces
{
    public interface IFileService
    {
        #region Create
        Task<bool> CreateFileFromConsole(string filename);
        #endregion

        Task<bool> CreateFileFromContent(string filename, string content);

        #region Read
        Task<FileInfo> GetFileInfo(string filename);

        Task<string> ReadFileContent(string filename);
        #endregion

        #region Update
        Task<bool> AppendContentToFileFromConsole(string filename);

        Task<bool> AppendContentToFile(string filename, string content);

        Task<bool> RenameFile(string oldFilename, string newFilename);
        #endregion

        #region Delete
        Task<bool> DeleteFile(string filename);
        #endregion
    }
}
