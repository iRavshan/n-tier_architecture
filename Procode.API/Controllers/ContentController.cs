using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Procode.Service;
using Procode.Service.Interfaces;
using Procode.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Procode.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        private readonly IContentService contentService;

        public ContentController(IContentService contentService)
        {
            this.contentService = contentService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await contentService.GetAll());
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            return Ok(await contentService.GetById(Id));
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(ContentViewModel model)
        {
            await contentService.Create(model);
            return Ok();
        }

        [HttpPost]
        [Route("Delete")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            bool task = await contentService.Delete(Id);

            if (task) return Ok();

            return BadRequest();
        }

        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> Update(ContentViewModel model)
        {
            await contentService.Update(model);
            return Ok();
        }

        [HttpPost]
        [Route("LastContents")]
        public async Task<IActionResult> LastContents(int count)
        {
            return Ok(await contentService.LastContents(count));
        }

        [HttpGet]
        [Route("LastContent")]
        public async Task<IActionResult> LastContent()
        {
            return Ok(await contentService.LastContent());
        }
    }
}
