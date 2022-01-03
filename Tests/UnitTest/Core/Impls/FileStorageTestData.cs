using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Core.Abstractions;
using Core.Impls;

namespace UnitTest.Core.Impls;

public class  FileStorageTestData: IEnumerable<object[]>
{
    public IEnumerable<IFileStorage> FileStorages()
    {
        var baseStorage = new PotatoFileStorage(); 
        yield return baseStorage;
        yield return new ZipWrapperFileStorage(baseStorage);
    }

    public IEnumerable<string> Samples()
    {
        yield return "simple test text";
        
        yield return @"
            Potatoes, potatoes! They grow in the ground,

            When you dig them up they're muddy, brown and round,

            Potatoes, potatoes! Delicious mashed,

            But they don't taste so good if they've been bashed,

            Potatoes, potatoes! Steamy in their jacket,

            Potatoes, potatoes! Fresh in their packet,

            Potatoes, potatoes! Can be made into chips,

            Potatoes, potatoes! Are best when they're crisps!
        ";
    }

    public IEnumerable<(IFileStorage Storage, string Data)> Data()
    {
        foreach (var storage in FileStorages())
        foreach (var data in Samples())
            yield return (storage, data);
    }


    public IEnumerator<object[]> GetEnumerator() => Data()
        .Select(x => new object[] { x.Storage, x.Data})
        .GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}