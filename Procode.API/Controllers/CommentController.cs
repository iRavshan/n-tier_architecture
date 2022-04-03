using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Procode.Data.Interfaces;
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
    public class CommentController : ControllerBase
    {
        private readonly ICommentService commentService;

        public CommentController(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Create(CommentViewModel comment)
        {
            await commentService.Create(comment);
            return Ok();
        }

        [Route("GetAll")]
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await commentService.GetAll());
        }

        [Route("GetById")]
        [HttpGet]
        public async Task<IActionResult> GetById(Guid Id)
        {
            return Ok(await commentService.GetById(Id));
        }

        [Route("Update")]
        [HttpPut]
        public async Task<IActionResult> Update(CommentViewModel model)
        {
            await commentService.Update(model);
            return Ok();
        }
    
        [Route("Delete")]
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid Id)
        {
            if (await commentService.Delete(Id)) return Ok();
            return NotFound();
        }
    }
}
