# Projeto Itera 360

API ASP.NET Core 10 organizada em camadas para separar as responsabilidades da aplicacao. O exemplo implementa o cadastro de usuarios e usa Entity Framework Core com SQL Server para a persistencia.

## Arquitetura

As dependencias seguem o fluxo abaixo:

```text
Projeto360.Api -> Projeto360.Aplicacao -> Projeto360.Dominio
                    -> Projeto360.Repositorio -> Projeto360.Dominio
```

- **Projeto360.Api**: camada de entrada HTTP. As controllers recebem a requisicao, devolvem a resposta e dependem apenas de contratos da camada de Aplicacao.
- **Projeto360.Aplicacao**: concentra os casos de uso. Converte DTOs, coordena regras e acessa a persistencia por interfaces, como `IUsuarioRepositorio`.
- **Projeto360.Dominio**: contem as entidades e contratos fundamentais do negocio. Nao referencia API, banco de dados ou Entity Framework.
- **Projeto360.Repositorio**: implementa o acesso a dados com EF Core, `Projeto360DbContext` e os repositorios concretos.

Essa direcao e intencional: a API possui referencia de projeto somente para Aplicacao. Assim, a camada web nao conhece diretamente entidades de dominio, `DbContext` ou repositorios concretos. A infraestrutura fica encapsulada e pode mudar sem espalhar detalhes de persistencia pelas controllers.

## Injecao de dependencia

O `Program.cs` e o ponto de composicao da aplicacao. Ao chamar `builder.Services.SetupDependencyInjection()`, a API delega o registro das implementacoes ao metodo de extensao definido em Aplicacao.

O container deve associar cada contrato a sua implementacao com ciclo de vida `scoped`, isto e, uma instancia por requisicao HTTP:

```csharp
services.AddScoped<IUsuarioApplication, UsuarioApplication>();
services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
services.AddDbContext<Projeto360DbContext>(options =>
  options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));
```

Quando uma requisicao chega em `UsuarioController`, o ASP.NET Core cria a controller e injeta `IUsuarioApplication`. A implementacao `UsuarioApplication` recebe `IUsuarioRepositorio`, que por sua vez recebe o `Projeto360DbContext`. A controller permanece focada no protocolo HTTP, enquanto o caso de uso e a persistencia mantem responsabilidades independentes.

> **Importante:** atualmente `SetupDependencyInjection` registra apenas `IUsuarioRepositorio` e o `DbContext`. Inclua o registro de `IUsuarioApplication` acima para que `UsuarioController` possa ser resolvida em tempo de execucao.

Esse desenho prepara o aluno para praticas comuns no mercado: baixo acoplamento, inversao de dependencias, testes mais simples com mocks das interfaces e evolucao segura da infraestrutura. Em vez de controllers acessarem o banco diretamente, cada camada possui uma responsabilidade clara e contratos explicitos.

## Executar migrations

```
dotnet ef database update \
  --project Projeto360.Repositorio/Projeto360.Repositorio.csproj \
  --startup-project Projeto360.Api/Projeto360.Api.csproj \
  --context Projeto360DbContext \
  --connection "Data Source=projeto360.db"
```