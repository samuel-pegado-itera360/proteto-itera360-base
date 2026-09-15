
using Projeto360.Dominio;
using Projeto360.Repositorio.Contexto;
using Projeto360.Repositorio.Interfaces;

namespace Projeto360.Repositorio;

public class UsuarioRepositorio : BaseRepositorio<Usuario>, IUsuarioRepositorio
{
    public UsuarioRepositorio(Projeto360DbContext projeto360DbContext) : base(projeto360DbContext)
    { }
}
