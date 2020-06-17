using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Admin.Data;
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
            var fileStream = new FileStream("/Users/aburke/Desktop/dummy.pdf", FileMode.Open);
            var stream = new StreamReader(fileStream);
            var stringContent = await stream.ReadToEndAsync();
            var content = Encoding.UTF8.GetBytes(stringContent);

            fileStream.Dispose();
            stream.Dispose();

            var fileResource = new FileResource
            {
                Filename = "dummy.pdf",
                Filesize = 2024,
                Content = content
            };

            _context.FileResource.Add(fileResource);

            await _context.SaveChangesAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> DownloadResource(Guid id)
        {
            var fileResource = await _context.FileResource
                .FindAsync(id);

            using var memoryStream = new MemoryStream(fileResource.Content);
            return File(memoryStream, "application/pdf", "new-dummy.pdf");
        }
    }
}