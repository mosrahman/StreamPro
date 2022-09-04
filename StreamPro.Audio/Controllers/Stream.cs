using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Diagnostics;

namespace StreamPro.Audio.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class Stream : ControllerBase
    {

        [HttpGet("api/stream/{filename}")]
        public async Task<IActionResult> Get(string filename)
        {
            string path = "Media/" + filename;
            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite, 1024, FileOptions.Asynchronous | FileOptions.SequentialScan))
            {
                await stream.CopyToAsync(memory);

                Debug.WriteLine(memory.Length);
            }
            memory.Position = 0;
            return File(memory, "application/octet-stream", Path.GetFileName(path), true); //enableRangeProcessing = true
        }

    }
}
