using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Procode.Data.Interfaces;
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
        private readonly ICommentRepository commentRepo;

        public CommentController(ICommentRepository commentRepo)
        {
            this.commentRepo = commentRepo;
        }

        [Route("Create")]
        [HttpPost]
        public IActionResult Create(Comment comment)
        {
            return Ok();
        }
    }
}
