using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Procode.Service.Interfaces;
using Procode.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace Procode.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeakerController : ControllerBase
    {
        private readonly ISpeakerService speakerService;
        private readonly IWebHostEnvironment webHost;

        public SpeakerController(ISpeakerService speakerService, IWebHostEnvironment webHost)
        {
            this.speakerService = speakerService;
            this.webHost = webHost;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await speakerService.GetAll());
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            return Ok(await speakerService.GetById(Id));
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(SpeakerViewModel model)
        {
            await speakerService.Create(model);
            return Ok();
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            bool task = await speakerService.Delete(Id);

            if (task) return Ok();

            return BadRequest();
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(SpeakerViewModel model)
        {
            await speakerService.Update(model);
            return Ok();
        }

        [HttpPost]
        [Route("SetImage")]
        public async Task<IActionResult> SetImage(Guid Id, IFormFile file)
        {
            await speakerService.SetImage(Id, file);
            return Ok();
        }


        [HttpGet]
        [Route("GetImage")]
        public async Task<IActionResult> GetImage(Guid Id)
        {
            var speaker = await speakerService.GetById(Id);
            if (speaker is not null)
            {
                string path = Path.Combine(webHost.WebRootPath, $"Images/Speakers/{speaker.PhotoUrl}");
                byte[] file = await System.IO.File.ReadAllBytesAsync(path);
                return File(file, "octet/stream", Path.GetFileName(path));
            }
            else
            {
                return NotFound();
            }
        }
    }
}
