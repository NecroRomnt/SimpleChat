namespace Core.DTO;

public class FileDto
{
    public FileDto(string name, byte[] data)
    {
        Name = name;
        Data = data;
    }

    /// <summary>
    /// File name
    /// </summary>
    public string Name { get; }
    
    /// <summary>
    /// File data
    /// </summary>
    public byte[] Data { get; }

    /// <summary>
    /// Empty/Not exists file
    /// </summary>
    public static readonly FileDto Empty = new FileDto(string.Empty, Array.Empty<byte>());
}