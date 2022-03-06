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
        public async Task<IActionResult> GetById([FromBody]Guid Id)
        {
            return Ok(await contentService.GetById(Id));
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create([FromBody]ContentViewModel model)
        {
            contentService.Create(model);
            return Ok();
        }

        [HttpPost]
        [Route("Delete")]
        public IActionResult Delete(Guid Id)
        {
            contentService.Delete(Id);
            return Ok();
        }
    }
}
