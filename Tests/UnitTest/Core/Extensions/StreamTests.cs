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

}