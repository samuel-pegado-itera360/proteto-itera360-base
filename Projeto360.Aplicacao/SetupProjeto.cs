using Projeto360.Repositorio;
using Projeto360.Repositorio.Contexto;
using Projeto360.Repositorio.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Projeto360.Aplicacao;

public static class DependencyInjection
{
    public static void SetupDependencyInjection(this IServiceCollection services)
    {
        // Add your dependency injection configurations here
        services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
        services.AddDbContext<Projeto360DbContext>(options =>
            options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));
    }
}
