using Core.Abstractions;
using Core.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;

namespace SimpleChat.Extensions;

public static class FileExtension
{
    public static IFile ToFile(this IFormFile file)
    {
        return new SimpleFileImpl(file.FileName, file.OpenReadStream());
    }

    public static FileStreamResult ToFileStream(this IFile file) => new(file.Data, new MediaTypeHeaderValue("application/octet-stream"));
}