using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto360.Dominio;

namespace Projeto360.Repositorio.Configurations;

public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
	public void Configure(EntityTypeBuilder<Usuario> builder)
	{
		builder.Property(usuario => usuario.Nome)
			.HasMaxLength(64);

		builder.Property(usuario => usuario.Email)
			.HasMaxLength(128);
	}
}
