using Projeto360.Aplicacao.DTO;
using Projeto360.Aplicacao.Interfaces;
using Projeto360.Dominio;
using Projeto360.Repositorio.Interfaces;

namespace Projeto360.Aplicacao;

public class UsuarioApplication : IUsuarioApplication
{
    private readonly IUsuarioRepositorio _usuarioRepositorio;

    public UsuarioApplication(IUsuarioRepositorio usuarioRepositorio)
    {
        _usuarioRepositorio = usuarioRepositorio;
    }

    public async Task Criar(UsuarioDTO usuarioDTO)
    {
        var usuario = new Usuario
        {
            Nome = usuarioDTO.Nome,
            Email = usuarioDTO.Email
        };
        await _usuarioRepositorio.Criar(usuario);
    }
}
