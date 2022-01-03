namespace Core.Abstractions;

/// <summary>
/// Abstract file storage
/// </summary>
public interface IFileStorage
{
    /// <summary>
    /// Upload file to storage
    /// </summary>
    /// <param name="fileName">File name</param>
    /// <param name="data">File data</param>
    /// <returns>File id in storage</returns>
    Guid Upload(string fileName, Stream data);
    
    /// <summary>
    /// Get file from storage
    /// </summary>
    /// <param name="id">File id</param>
    /// <returns>Information about file</returns>
    IFile Download(Guid id);
}