using System.IO;
using System.Linq;
using Core.Abstractions;
using Xunit;

namespace UnitTest.Core.Impls;

[Collection(nameof(IFileStorage))]
public class FileStorageTests
{
    [Theory]
    [ClassData(typeof(FileStorageTestData))]
    public void Roundtrip(IFileStorage storage, string testData)
    {
        const string filename = "potato.poem";
        using var memory = new MemoryStream(testData.Select(x => (byte)x).ToArray());
        
        var id = storage.Upload(filename, memory);
        var sample = storage.Download(id);

        using var reader = new StreamReader(sample.Data);
        var samplePoem = reader.ReadToEnd();
        
        Assert.Equal(filename, sample.Name);
        Assert.Equal(testData, samplePoem);
    }
}