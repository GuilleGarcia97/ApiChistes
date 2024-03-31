using ApiChistes.Data;
using ApiChistes.Models;
using ApiChistes.Models.DTO;
using ApiChistes.Services.ChisteService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiChistes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChistesController : ControllerBase
    {
     
        public readonly IChisteService _chisteService;

        public ChistesController(IChisteService chisteService)
        {
            _chisteService = chisteService;
        }
        // GET: Todos los chistes
        [HttpGet]
        public async Task<IActionResult> GetAllChistes()
        {
            return Ok(await _chisteService.GetAllChistes());
        }


        // GET: Unico chiste

        [HttpGet("{id}")]
        public async Task<IActionResult> GetChiste(int id)
        {
            var chiste = await _chisteService.GetChiste(id);

            if (chiste == null) { return NotFound("Chiste no encontrado."); }
            return Ok(chiste);
        }

        // POST chiste
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> PostChiste(ChisteDto pChiste)
        {
            return Ok(await _chisteService.PostChiste(pChiste, User?.Identity?.Name));
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> ModifyChiste(Chiste chiste)
        {
            var auxChiste = await _chisteService.ModifyChiste(chiste);
            if (auxChiste == null) { return NotFound("Chiste no encontrado."); }

            return Ok(auxChiste);
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeleteChiste(int id)
        {
            var auxChiste = await _chisteService.DeleteChiste(id); 
            if (auxChiste == null) { return NotFound("Chiste no encontrado."); }

            return Ok(auxChiste);
        }




    }
}
