using Projeto360.Dominio.Interfaces;

namespace Projeto360.Dominio;

public class Usuario : IEntidade
{
    public int Id { get; set; }
    public string Nome { get; set; } = "";
    public string Email { get; set; } = "";
}