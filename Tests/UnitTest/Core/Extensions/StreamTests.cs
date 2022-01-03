using System.IO;
using System.Text;
using Core.Extensions;
using Xunit;

namespace UnitTest.Core.Extensions;

public class StreamTests
{
    /// <summary>
    /// Test converting Array -> Stream -> Array 
    /// </summary>
    /// <param name="testData">Test arrays</param>
    [Theory]
    [InlineData(new byte[] {1,2,3,4,5,6,7,8,9,10})]
    public void Roundtrip(byte[] testData)
    {
        using var stream = testData.ToStream();
        var sample = stream.ToArray();
        
        Assert.Equal(testData, sample);
    }


    [Fact]
    public void ZipRoundtrip()
    {
        var data = "Simple test text Примечания для тех, кто наследует этот метод";
        var bytes = Encoding.Unicode.GetBytes(data);
        using var memory = new MemoryStream(bytes);

        using var compressed = memory.Compress();
        using var decompressed = compressed.Decompress();

        var sample = Encoding.Unicode.GetString(decompressed.ToArray());
        
        Assert.Equal(data, sample);
    } 
}