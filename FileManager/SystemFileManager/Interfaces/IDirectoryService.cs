using System.IO;
using System.Threading.Tasks;

namespace FileManager.SystemFileManager.Interfaces
{
    public interface IDirectoryService
    {
        #region Create
        Task<bool> CreateDirectory(string directoryName);
        #endregion

        #region Read
        Task<DirectoryInfo> GetDirectoryInfo(string directoryName);
        #endregion

        #region Update
        Task<bool> RenameDirectory(string oldDirectoryName, string newDirectoryName);
        #endregion

        #region Delete
        Task<bool> DeleteDirectory(string directoryName, bool recursive = false);
        #endregion
    }
}
