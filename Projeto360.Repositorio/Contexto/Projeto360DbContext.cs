using Microsoft.EntityFrameworkCore;
using Projeto360.Dominio;
using Projeto360.Repositorio.Configurations;

namespace Projeto360.Repositorio.Contexto;

public class Projeto360DbContext : DbContext
{
    public DbSet<Usuario> Usuarios { get; set; }

    public Projeto360DbContext(DbContextOptions<Projeto360DbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
        base.OnModelCreating(modelBuilder);
    }
}