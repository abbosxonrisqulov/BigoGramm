using BigoGramm.Models;
using BigoGramm.Service.DTOs.Comment;
using BigoGramm.Service.DTOs.Post;
using BigoGramm.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BigoGramm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService CommentService;

        public CommentController(ICommentService CommentService)
        {
            this.CommentService = CommentService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CommentAsync(CommentCreationDto dto)
            => Ok(new Response
            {
                StatusCode = 200,
                Message = "Succes",
                Data = await CommentService.CreateAsync(dto)
            });

    }
}
