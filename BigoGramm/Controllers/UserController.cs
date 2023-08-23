using BigoGramm.Models;
using BigoGramm.Service.DTOs.User;
using BigoGramm.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BigoGramm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> PostAsync(UserCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Succes",
            Data = await userService.CreateAsync(dto)
        });

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync(long id)
            => Ok(new Response
            {
                StatusCode = 200,
                Message = "Succes",
                Data = await userService.DeleteAsync(id)
            });

        [HttpPut("Update")]

        public async Task<IActionResult> PutAsync(UserUpdateDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Succes",
            Data = await userService.UpdateAsync(dto)
        });

        [HttpGet("api/get/id")]
        public async Task<IActionResult> GetById(long Id)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Succes",
            Data = await userService.GetAsync(Id)
        });

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll()
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Succes",
            Data = await userService.GetAllUsersAsync()
        });
    }
}
