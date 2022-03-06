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
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            this.feedbackService = feedbackService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await feedbackService.GetAll());
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> GetById(Guid Id)
        {
            return Ok(await feedbackService.GetById(Id));
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(FeedbackViewModel model)
        {
            await feedbackService.Create(model);
            return Ok();
        }

        [HttpPost]
        [Route("Delete")]
        public async Task<IActionResult> Delete(Guid Id)
        {
            bool task = await feedbackService.Delete(Id);

            if (task) return Ok();

            return BadRequest();
        }
    }
}
