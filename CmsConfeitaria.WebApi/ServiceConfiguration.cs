using CmsConfeitaria.Business.Repositories;
using CmsConfeitaria.Business.Repositories.Interfaces;
using CmsConfeitaria.Business.Services;
using CmsConfeitaria.Business.Services.Interfaces;
using System.Runtime.CompilerServices;

namespace CmsConfeitaria.WebApi
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection Configurar(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ReceitaRespository, ReceitaRepositoryImpl>();
            serviceCollection.AddScoped<IngredienteRepository, IngredienteRepositoryImpl>();
            serviceCollection.AddScoped<UnidadeMedidaRepository, UnidadeMedidaRepositoryImpl>();
            serviceCollection.AddScoped<ReceitaIngredienteRepository, ReceitaIngredienteRepositoryImpl>();
            serviceCollection.AddScoped<CompraRepository, CompraIngredienteRepositoryImpl>();
            serviceCollection.AddScoped<RelatorioService, RelatorioServiceImpl>();
            serviceCollection.AddScoped<UsuarioRepository, UsuarioRepositoryImpl>();
            serviceCollection.AddScoped<AutenticacaoService, AutenticacaoServiceImpl>();
            return serviceCollection;
        }

    }
}
