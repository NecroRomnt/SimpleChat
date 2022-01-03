using Core.Abstractions;

namespace Core.Extensions;

/// <summary>
/// Extension for file storage
/// </summary>
public static class FileStorageExtension
{
    /// <summary>
    /// Upload file to storage
    /// </summary>
    /// <param name="storage">File storage implementation</param>
    /// <param name="file">File name and data</param>
    /// <returns>File id in storage</returns>
    public static Guid Upload(this IFileStorage storage, IFile file)
        => storage.Upload(file.Name, file.Data);
}