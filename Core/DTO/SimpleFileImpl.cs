using Core.Abstractions;

namespace Core.DTO;

/// <summary>
/// Impl of the <see cref="IFile"/>
/// </summary>
public class SimpleFileImpl : IFile, IDisposable
{
    public SimpleFileImpl(string name, Stream data)
    {
        Name = name;
        Data = data;
    }

    /// <inheritdoc cref="IFile.Name"/>
    public string Name { get; }
    
    /// <inheritdoc cref="IFile.Data"/>
    public Stream Data { get; }

    public void Dispose()
    {
        Data?.Dispose();
    }
}