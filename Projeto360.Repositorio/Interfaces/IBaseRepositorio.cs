using Projeto360.Dominio.Interfaces;

namespace Projeto360.Repositorio.Interfaces
{
    public interface IBaseRepositorio<T> where T : class, IEntidade
{
    Task Atualizar(T entidade);
    Task<T> Criar(T entidade);
    Task<IEnumerable<T>> Listar();
    Task<T?> Obter(int id);
    Task Remover(T entidade);
}
}