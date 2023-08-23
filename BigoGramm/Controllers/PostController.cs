using BigoGramm.Models;
using BigoGramm.Service.DTOs.Post;
using BigoGramm.Service.DTOs.User;
using BigoGramm.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BigoGramm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : Controller
    {
        private readonly IPostService PostService;

        public PostController(IPostService PostService)
        {
            this.PostService = PostService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> PostAsync(PostCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Succes",
            Data = await PostService.CreateAsync(dto)
        });

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync(long id)
            => Ok(new Response
            {
                StatusCode = 200,
                Message = "Succes",
                Data = await PostService.DeleteAsync(id)
            });

        [HttpPut("Update")]

        public async Task<IActionResult> PutAsync(PostUpdateDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Succes",
            Data = await PostService.UpdateAsync(dto)
        });

        [HttpGet("api/get/id")]
        public async Task<IActionResult> GetById(long Id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Succes",
            Data = await PostService.GetAsync(Id)
        });

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Succes",
            Data = await PostService.GetAllPostsAsync()
        });
    }
}
