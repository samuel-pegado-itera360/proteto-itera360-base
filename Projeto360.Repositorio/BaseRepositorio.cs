
using Projeto360.Dominio.Interfaces;
using Projeto360.Repositorio.Contexto;
using Microsoft.EntityFrameworkCore;
using Projeto360.Repositorio.Interfaces;

namespace Projeto360.Repositorio;

public abstract class BaseRepositorio<T> : IBaseRepositorio<T> where T : class, IEntidade
{
    private readonly Projeto360DbContext _projeto360DbContext;
    public BaseRepositorio(Projeto360DbContext projeto360DbContext)
    {
        _projeto360DbContext = projeto360DbContext;
    }

    public async Task<T?> Obter(int id)
    {
        return await _projeto360DbContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<T> Criar(T entidade)
    {
        var entity = _projeto360DbContext.Set<T>().Add(entidade).Entity;
        await _projeto360DbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<IEnumerable<T>> Listar()
    {
        return await _projeto360DbContext.Set<T>().ToListAsync();
    }

    public async Task Atualizar(T entidade)
    {
        _projeto360DbContext.Entry(entidade).State = EntityState.Modified;
        await _projeto360DbContext.SaveChangesAsync();

    }

    public async Task Remover(T entidade)
    {
        _projeto360DbContext.Set<T>().Remove(entidade);
        await _projeto360DbContext.SaveChangesAsync();
    }
}
