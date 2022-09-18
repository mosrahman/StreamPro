using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Diagnostics;
using StreamPro.Audio.Repositories;

namespace StreamPro.Audio.Controllers
{
    [ApiController]
    public class Stream : ControllerBase
    {
        private IStreamRepository streamRepository;
        public Stream(IStreamRepository streamRepository)
        {
            this.streamRepository = streamRepository;
        }

        [ApiVersion("1.0")]
        [HttpGet("api/v{version:apiVersion}/stream/{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var memory = await this.streamRepository.GetStream(id);

            return File(memory, "application/octet-stream", true); //enableRangeProcessing = true
        }

    }
}
