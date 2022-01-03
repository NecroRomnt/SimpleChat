namespace Core.Abstractions;

/// <summary>
/// Basic file information
/// </summary>
public interface IFile
{
    /// <summary>
    /// File name
    /// </summary>
    string Name { get; }
    
    /// <summary>
    /// File data
    /// </summary>
    Stream Data { get; }
}