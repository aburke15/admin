using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Admin.Data.Access;
using Admin.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Admin.Api.Controllers
{
    public class TestController : BaseApiController
    {
        private readonly ILogger<TestController> _logger;
        private readonly IrohContext _context;

        public TestController(IrohContext context, ILogger<TestController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task InsertIntoDatabase()
        {
            var path = "/Users/aburke/Desktop/dummy.pdf";
            using var fileStream = new FileStream(path, FileMode.Open);
            using var stream = new MemoryStream();

            await fileStream.CopyToAsync(stream);

            var fileResource = new FileResource
            {
                Filename = "dummy.pdf",
                Filesize = 2024,
                Content = stream.ToArray()
            };

            _context.FileResource.Add(fileResource);

            Console.WriteLine(fileResource.Id);

            await _context.SaveChangesAsync();
        }

        [HttpGet("{id:guid}")]
        public async Task<FileContentResult> DownloadResource(Guid id)
        {
            var fileResource = await _context.FileResource
                .FindAsync(id);

            return File(fileResource.Content, "application/pdf", "new-dummy.pdf");
        }
    }
}