using Core.Abstractions;
using Core.DTO;
using Core.Extensions;

namespace Core.Impls;

public class ZipWrapperFileStorage: IFileStorage
{
    private readonly IFileStorage _storage;

    public ZipWrapperFileStorage(IFileStorage storage)
    {
        _storage = storage;
    }


    public Guid Upload(string fileName, Stream data)
    {
        var zipped = data.Compress();
        return _storage.Upload(fileName, zipped);
    }

    public IFile Download(Guid id)
    {
        var (name, zipData) = _storage.Download(id);
        var data = zipData.Decompress();

        return new SimpleFileImpl(name, data);
    }
}