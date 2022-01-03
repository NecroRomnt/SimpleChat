using Core.Abstractions;

namespace Core.Extensions;

/// <summary>
/// <see cref="IFile"/> extension
/// </summary>
public static class FileExtension
{
    /// <summary>
    /// Deconstruct file implementation 
    /// </summary>
    /// <param name="file">Source file</param>
    /// <param name="name">File name</param>
    /// <param name="data">File stream</param>
    public static void Deconstruct(this IFile file, out string name, out Stream data)
    {
        name = file.Name;
        data = file.Data;
    }
}