using System;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleChat.Extensions;

namespace SimpleChat.Controllers;

public class FilesController : Controller
{
    private readonly IFileService _fileService;

    public FilesController(IFileService fileService)
    {
        _fileService = fileService;
    }
    
    [HttpPut("")]
    public IActionResult Upload(IFormFile file)
    {
        using var f = file.ToFile();
        return Json(_fileService.Upload(f));
    }

    [HttpGet("")]
    public IActionResult Download(Guid fileId)
    {
        var file = _fileService.Download(fileId);
        return file.ToFileStream();
    }
}