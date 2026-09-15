using Projeto360.Aplicacao.DTO;

namespace Projeto360.Aplicacao.Interfaces;

public interface IUsuarioApplication
{
    Task Criar(UsuarioDTO usuarioDTO);
}