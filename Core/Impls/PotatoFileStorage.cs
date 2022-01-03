using Core.Abstractions;
using Core.DTO;
using Core.Extensions;

namespace Core.Impls;

/// <summary>
/// Simple file storage for testing 
/// </summary>
public class PotatoFileStorage: IFileStorage
{
    private Dictionary<Guid, FileDto> _data;

    public PotatoFileStorage()
    {
        _data = new Dictionary<Guid, FileDto>();
    }

    /// <inheritdoc cref="IFileStorage.Upload"/>
    public Guid Upload(string fileName, Stream data)
    {
        var id = Guid.NewGuid();
        var value = data.ToArray();

        var dto = new FileDto(fileName, value);
        _data.Add(id, dto);
        
        return id;
    }

    /// <inheritdoc cref="IFileStorage.Download"/>
    public IFile Download(Guid id)
    {
        var fileInfo = _data.ContainsKey(id)
            ? _data[id]
            : FileDto.Empty;
        var memory = fileInfo.Data.ToStream();

        return new SimpleFileImpl(fileInfo.Name, memory);
    }
}