using System.IO;
using System.Text;
using Core.Abstractions;
using Core.Extensions;
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
        var bytes = Encoding.Unicode.GetBytes(testData);
        using var memory = new MemoryStream(bytes);
        
        var id = storage.Upload(filename, memory);
        var sample = storage.Download(id);

        var samplePoem = Encoding.Unicode.GetString(sample.Data.ToArray());
        
        Assert.Equal(filename, sample.Name);
        Assert.Equal(testData, samplePoem);
    }
}