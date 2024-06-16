using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sound.Data.DbContexts;

namespace Sound.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class AudioFileController : ControllerBase
    {
        public AudioFileController(SoundDbContext soundDbContext)
        {
            SoundDbContext = soundDbContext;
        }

        public SoundDbContext SoundDbContext { get; }

        [Route("get-audios")]
        [HttpGet]
        public IActionResult GetAllAudio()
        {
            return Ok(SoundDbContext.AudioFiles);
        }

        [Route("get-audio-by-id/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetAudioById(Guid id)
        {
            return Ok(await SoundDbContext.AudioFiles.FirstOrDefaultAsync(x => x.Id == id));
        }

    }
}