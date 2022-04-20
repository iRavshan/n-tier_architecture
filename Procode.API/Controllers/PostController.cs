using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    public class PostController : ControllerBase
    {
        private readonly IPostService postService;

        public PostController(IPostService postService)
        {
            this.postService = postService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await postService.GetAll());
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            return Ok(await postService.GetById(Id));
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(PostViewModel model)
        {
            await postService.Create(model);
            return Ok();
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            bool task = await postService.Delete(Id);

            if (task) return Ok();

            return BadRequest();
        }

        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(PostViewModel model)
        {
            await postService.Update(model);
            return Ok();
        }

        [HttpGet]
        [Route("LastContents")]
        public async Task<IActionResult> LastContents(int count)
        {
            return Ok(await postService.LastContents(count));
        }

        [HttpGet]
        [Route("LastContent")]
        public async Task<IActionResult> LastContent()
        {
            return Ok(await postService.LastContent());
        }
    }
}
