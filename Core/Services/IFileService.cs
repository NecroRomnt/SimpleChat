using Core.Abstractions;

namespace Core.Services;

public interface IFileService
{
    /// <summary>
    /// Upload file to storage
    /// </summary>
    /// <param name="file">File name and data</param>
    /// <returns>File id in storage</returns>
    Guid Upload(IFile file);

    /// <summary>
    /// Get file from storage
    /// </summary>
    /// <param name="id">File id</param>
    /// <returns>Information about file</returns>
    IFile Download(Guid id);
}