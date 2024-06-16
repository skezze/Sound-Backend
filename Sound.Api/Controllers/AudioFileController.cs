using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;
using Sound.Api.Models;
using Sound.Api.Services;
using Sound.Data.DbContexts;

namespace Sound.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class AudioFileController : ControllerBase
    {
        private readonly SoundDbContext soundDbContext;
        private readonly TokenService tokenService;
        private readonly IDataProtectionProvider dataProtectionProvider;
        private readonly UserManager<User> userManager;

        public AudioFileController(SoundDbContext soundDbContext,
                                   TokenService tokenService,
                                   IDataProtectionProvider dataProtectionProvider,
                                   UserManager<User> userManager)
        {
            this.soundDbContext = soundDbContext;
            this.tokenService = tokenService;
            this.dataProtectionProvider = dataProtectionProvider;
            this.userManager = userManager;
        }

        [Route("get-audios")]
        [HttpGet]
        public IActionResult GetAllAudio()
        {
            return Ok(soundDbContext.AudioFiles);
        }

        [Route("get-audio-by-id/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetAudioById(Guid id)
        {
            return Ok(await soundDbContext.AudioFiles.FirstOrDefaultAsync(x => x.Id == id));
        }

        [Route("get-custom-collections")]
        [HttpGet, Authorize]
        public async Task<IActionResult> GetCustomCollection()
        {
            var token = Request.Headers[HeaderNames.Authorization].ToString();
            var protector = dataProtectionProvider.CreateProtector("YourPurpose");
            if (token != null)
            {
                var decodedData = await tokenService.DecodeAsync(token, protector, userManager);
                var user = await userManager.FindByIdAsync(decodedData.UserId);
                if (user != null)
                {
                    return Ok(user.CustomCollections);
                }
            }
            return BadRequest(new {message = "token is null or user isn`t finded" });
        }

    }
}