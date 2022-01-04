using Core.Abstractions;
using Core.Extensions;

namespace Core.Services;

/// <summary>
/// Service working with files
/// </summary>
/// <remarks>Temporarily degenerated</remarks>
public class FileService : IFileService
{
    private readonly IFileStorage _storage;

    public FileService(IFileStorage storage)
    {
        _storage = storage;
    }
    
    /// <summary>
    /// Upload file to storage
    /// </summary>
    /// <param name="file">File name and data</param>
    /// <returns>File id in storage</returns>
    public Guid Upload(IFile file)
    {
        return _storage.Upload(file);
    }
    
    /// <summary>
    /// Get file from storage
    /// </summary>
    /// <param name="id">File id</param>
    /// <returns>Information about file</returns>
    public IFile Download(Guid id)
    {
        return _storage.Download(id);
    }
}