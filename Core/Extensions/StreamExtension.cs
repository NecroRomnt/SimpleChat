namespace Core.Extensions;

/// <summary>
/// Extension for streams
/// </summary>
public static class StreamExtension
{
    /// <summary>
    /// Get stream data as byte array
    /// </summary>
    /// <param name="input">Input stream</param>
    /// <returns>Bin data</returns>
    public static byte[] ToArray(this Stream input)
    {
        var buffer = new byte[8 * 1024];
        using var memory = new MemoryStream();

        int read;
        while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
        {
            memory.Write(buffer, 0, read);
        }

        return memory.ToArray();
    }
}