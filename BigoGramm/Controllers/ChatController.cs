using BigoGramm.Models;
using BigoGramm.Service.DTOs.Chat;
using BigoGramm.Service.DTOs.User;
using BigoGramm.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BigoGramm.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IChatService ChatService;

        public ChatController(IChatService ChatService)
        {
            this.ChatService = ChatService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> PostAsync(ChatCreationDto dto)
        => Ok(new Response
        {
            StatusCode = 200,
            Message = "Succes",
            Data = await ChatService.CreateAsync(dto)
        });

        [HttpPut("Update")]
        public async Task<IActionResult> PutAsync(ChatUpdateDto dto)
            => Ok(new Response
            {
                StatusCode = 200,
                Message = "Succes",
                Data = await ChatService.UpdateAsync(dto)
            });

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync(long id)
            => Ok(new Response
            {
                StatusCode = 200,
                Message = "Succes",
                Data = await ChatService.DeleteAsync(id)
            });
    }
}
