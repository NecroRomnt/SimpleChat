using System;
using System.IO;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleChat.Extensions;

namespace SimpleChat.Controllers;

[Route("file")]
public class FilesController : Controller
{
    private readonly IFileService _fileService;

    public FilesController(IFileService fileService)
    {
        _fileService = fileService;
    }
    
    [HttpPut()]
    public IActionResult Upload(IFormFile file)
    {
        using var f = file.ToFile();
        return Json(_fileService.Upload(f));
    }

    [HttpGet("{id:guid}")]
    public IActionResult Download(Guid id)
    {
        var file = _fileService.Download(id);
        if (file == default)
        {
            return new BadRequestResult();
        }

        var fileName = Path.GetFileNameWithoutExtension(file.Name);
        Response.Headers.Add("content-disposition", @$"attachment; name=""{fileName}""; filename=""{file.Name}""");
        return file.ToFileStream();
    }
}