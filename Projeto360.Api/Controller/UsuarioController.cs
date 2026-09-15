using Microsoft.AspNetCore.Mvc;
using Projeto360.Aplicacao.DTO;
using Projeto360.Aplicacao.Interfaces;

[ApiController]
[Route("api/[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioApplication _usuarioApplication;
    public UsuarioController(IUsuarioApplication usuarioApplication)
    {
        _usuarioApplication = usuarioApplication;
    }

    [HttpPost]
    public async Task<IActionResult> Criar([FromBody] UsuarioDTO usuarioDTO)
    {
        await _usuarioApplication.Criar(usuarioDTO);
        return Ok();
    }
}