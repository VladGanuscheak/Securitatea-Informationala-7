using FileManager.SystemFileManager.Interfaces;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace FileManager.SystemFileManager
{
    public class FileManager : IFileManager
    {
        #region Private methods
        private void RiseError(Exception exception)
        {
            var category = nameof(exception.GetType);
            Debug.WriteLine($"{category}: {exception.Message}");
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();
        #endregion

        /// <summary>
        /// Asynchronous method for appending text to the indicated file.
        /// Returnes true if the operation succeded, otherwise - false.
        /// </summary>
        /// <param name="filename">The full path from the program to the corresponding file.</param>
        /// <returns></returns>
        public async Task<bool> AppendContentToFileFromConsole(string filename)
        {
            return await Task.Run(() =>
            {
                try
                {
                    AllocConsole();
                    var newContent = Console.ReadLine();
                    while (newContent.ToLower() != "exit")
                    {
                        File.AppendAllText(filename, newContent + Environment.NewLine);
                        newContent = Console.ReadLine();
                    }
                    return true;
                }
                catch(Exception exception)
                {
                    RiseError(exception);
                    return false;
                }
            });
        }

        /// <summary>
        /// Creates a new directory inside the current one. Returnes true if the operation
        /// succeded, otherwise - false.
        /// </summary>
        /// <param name="directoryName"></param>
        /// <returns></returns>
        public async Task<bool> CreateDirectory(string directoryName)
        {
            return await Task.Run(() =>
            {
                try
                {
                    if (directoryName != String.Empty)
                    {
                        Directory.CreateDirectory(directoryName);
                        return Directory.Exists(directoryName);
                    }
                    return false;
                }
                catch(Exception exception)
                {
                    RiseError(exception);
                    return false;
                }
            });
        }

        /// <summary>
        /// Asynchronous method for writing the Console contact into the indicated file. 
        /// The input terminates with 'exit' keyword (not case sensetive). Returnes true if operation succeded,
        /// otherwise - false.
        /// </summary>
        /// <param name="filename">The full path from the program to the desired file.</param>
        /// <returns></returns>
        public async Task<bool> CreateFileFromConsole(string filename)
        {
            return await Task.Run(() =>
            {
                try
                {
                    using (var streamWriter = new StreamWriter(filename))
                    {
                        AllocConsole();
                        var newContent = Console.ReadLine();
                        while (newContent.ToLower() != "exit")
                        {
                            streamWriter.Write(newContent + Environment.NewLine);
                            newContent = Console.ReadLine();
                        }
                        return true;
                    }
                }
                catch(Exception exception)
                {
                    RiseError(exception);
                    return false;
                }
            });
        }

        /// <summary>
        /// Asynchronous method which deletes the directory. Returns true if the folder has been deleted,
        /// otherwise - false. Has optional field 'recursive' (Set implicitely true in order to delete the whole
        /// content of the file [Even if the directory isn't empty]).
        /// </summary>
        /// <param name="directoryName"></param>
        /// <returns></returns>
        public async Task<bool> DeleteDirectory(string directoryName, bool recursive = false)
        {
            return await Task<bool>.Run(() =>
            {
                try
                {
                    if (Directory.Exists(directoryName))
                    {
                        Directory.Delete(directoryName, recursive);
                        return !Directory.Exists(directoryName);
                    }
                    return true;
                }
                catch (Exception exception)
                {
                    RiseError(exception);
                    return false;
                }
            });
        }

        /// <summary>
        /// Asynchronous method deletes the indicated file and returnes true if operation was successfull,
        /// otherwise - false.
        /// </summary>
        /// <param name="filename">The path from the program to the desired file.</param>
        /// <returns></returns>
        public async Task<bool> DeleteFile(string filename)
        {
            return await Task<bool>.Run(() => {
                try
                {
                    if (File.Exists(filename))
                    {
                        File.Delete(filename);
                        return !File.Exists(filename);
                    }
                    return true;
                }
                catch(Exception exception)
                {
                    RiseError(exception);
                    return false;
                }
            });
        }

        /// <summary>
        /// Asynchronous method returnes explicit information about the indicated directory,
        /// otherwise - null value.
        /// </summary>
        /// <param name="directoryName"></param>
        /// <returns></returns>
        public async Task<DirectoryInfo> GetDirectoryInfo(string directoryName)
        {
            return await Task.Run(() =>
            {
                try
                {
                    return new DirectoryInfo(directoryName);
                }
                catch(Exception exception)
                {
                    RiseError(exception);
                    return null;
                }
            });
        }

        /// <summary>
        /// Returns explicit info about the file. In case if something went wrong
        /// the result will be null value.
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public async Task<FileInfo> GetFileInfo(string filename)
        {
            return await Task.Run(() =>
            {
                try
                {
                    return new FileInfo(filename);
                }
                catch(Exception exception)
                {
                    RiseError(exception);
                    return null;
                }
            });
        }

        /// <summary>
        /// Returns the content of the specified file. If something went wrong the result will be null.
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public async Task<string> ReadFileContent(string filename)
        {
            return await Task.Run(() =>
            {
                try
                {
                    return File.ReadAllText(filename);
                }
                catch (Exception exception)
                {
                    RiseError(exception);
                    return null;
                }
            });
        }

        /// <summary>
        /// Method which renames the old directory. Returns true if the operation succeded, otherwise - false.
        /// </summary>
        /// <param name="oldDirectoryName"></param>
        /// <param name="newDirectoryName"></param>
        /// <returns></returns>
        public async Task<bool> RenameDirectory(string oldDirectoryName, string newDirectoryName)
        {
            return await Task.Run(() =>
            {
                try
                {
                    if (Directory.Exists(oldDirectoryName))
                    {
                        if (newDirectoryName != String.Empty)
                        {
                            Directory.Move(oldDirectoryName, newDirectoryName);
                            return Directory.Exists(newDirectoryName);
                        }
                    }
                    return false;
                }
                catch(Exception exception)
                {
                    RiseError(exception);
                    return false;
                }
            });
        }

        /// <summary>
        /// Renames old file. Returns true if the operation succeded, otherwise - false.
        /// </summary>
        /// <param name="oldFilename"></param>
        /// <param name="newFilename"></param>
        /// <returns></returns>
        public async Task<bool> RenameFile(string oldFilename, string newFilename)
        {
            return await Task.Run(() =>
            {
                try
                {
                    if (File.Exists(oldFilename))
                    {
                        if (newFilename != String.Empty)
                        {
                            File.Move(oldFilename, newFilename);
                            return File.Exists(newFilename);
                        }
                    }
                    return false;
                }
                catch(Exception exception)
                {
                    RiseError(exception);
                    return false;
                }
            });
        }

        /// <summary>
        /// Creates the file with the indicated content. Result true means success, otherwise - failure.
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public async Task<bool> CreateFileFromContent(string filename, string content)
        {
            return await Task.Run(() =>
            {
                try
                {
                    File.WriteAllText(filename, content);
                    return true;
                }
                catch (Exception exception)
                {
                    RiseError(exception);
                    return false;
                }
            });
        }


        /// <summary>
        /// Appends the content to the indicated file. True - success, otherwise - failure.
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public async Task<bool> AppendContentToFile(string filename, string content)
        {
            return await Task.Run(() =>
            {
                try
                {
                    File.AppendAllText(filename, content + Environment.NewLine);
                    return true;
                }
                catch (Exception exception)
                {
                    RiseError(exception);
                    return false;
                }
            });
        }
    }
}
