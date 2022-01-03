using System;
using System.IO;
using System.Linq;
using System.Text;
using Core.Extensions;
using Core.Impls;
using Xunit;

namespace UnitTest.Core.Impls;

public class PotatoFileStorageTests
{
    [Theory]
    [InlineData(@"
        Potatoes, potatoes! They grow in the ground,

        When you dig them up they're muddy, brown and round,

        Potatoes, potatoes! Delicious mashed,

        But they don't taste so good if they've been bashed,

        Potatoes, potatoes! Steamy in their jacket,

        Potatoes, potatoes! Fresh in their packet,

        Potatoes, potatoes! Can be made into chips,

        Potatoes, potatoes! Are best when they're crisps!
    ")]
    public void Roundtrip(string testData)
    {
        var fileService = new PotatoFileStorage();
        
        const string filename = "potato.poem";
        using var memory = new MemoryStream(testData.Select(x => (byte)x).ToArray());
        
        var id = fileService.Upload(filename, memory);
        var sample = fileService.Download(id);

        using var reader = new StreamReader(sample.Data);
        var samplePoem = reader.ReadToEnd();
        
        Assert.Equal(filename, sample.Name);
        Assert.Equal(testData, samplePoem);
    }
}