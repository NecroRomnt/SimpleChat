using System.IO.Compression;

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

    /// <summary>
    /// Get stream from byte array
    /// </summary>
    /// <param name="input">Input byte array</param>
    /// <returns>Stream</returns>
    public static Stream ToStream(this byte[] input)
    {
        return new MemoryStream(input);
    }

    /// <summary>
    /// Zip stream
    /// </summary>
    /// <param name="input">Input stream</param>
    /// <returns>Zipped stream</returns>
    public static Stream Compress(this Stream input)
    {
        var result = new MemoryStream();
        
        var compressor = new GZipStream(result, CompressionMode.Compress);
        input.CopyTo(compressor);
        compressor.Flush();
        
        result.Seek(0, SeekOrigin.Begin);
        
        return result;
    }

    /// <summary>
    /// Unzip stream
    /// </summary>
    /// <param name="input">Unzip stream</param>
    /// <returns>Unzipped stream</returns>
    public static Stream Decompress(this Stream input)
    {
        var result = new MemoryStream();
        
        using var decompressor = new GZipStream(input, CompressionMode.Decompress);
        decompressor.CopyTo(result);
        decompressor.Flush();
        
        result.Seek(0, SeekOrigin.Begin);

        return result;
    }
}