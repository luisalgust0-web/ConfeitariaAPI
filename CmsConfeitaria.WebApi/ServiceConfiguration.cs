using CmsConfeitaria.Business.Repositories;
using CmsConfeitaria.Business.Repositories.Interfaces;
using CmsConfeitaria.Business.Services;
using CmsConfeitaria.Business.Services.Interfaces;
using CmsConfeitaria.Core.Entity;
using System.Runtime.CompilerServices;

namespace CmsConfeitaria.WebApi
{
    public static class ServiceConfiguration
    {
        public static IServiceCollection Configurar(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<UsuarioRepository, UsuarioRepositoryImpl>();
            serviceCollection.AddScoped<IngredienteRepository, IngredienteRepositoryImpl>();
            serviceCollection.AddScoped<ReceitaRespository, ReceitaRepositoryImpl>();
            serviceCollection.AddScoped<UnidadeMedidaRepository, UnidadeMedidaRepositoryImpl>();
            serviceCollection.AddScoped<ReceitaIngredienteRepository, ReceitaIngredienteRepositoryImpl>();
            serviceCollection.AddScoped<CompraIngredienteRepository, CompraIngredienteRepositoryImpl>();

            serviceCollection.AddScoped<UsuarioService, UsuarioServiceImpl>();
            serviceCollection.AddScoped<IngredienteService, IngredienteServiceImpl>();
            serviceCollection.AddScoped<ReceitaService, ReceitaServiceImpl>();
            serviceCollection.AddScoped<RelatorioService, RelatorioServiceImpl>();
            serviceCollection.AddScoped<AutenticacaoService, AutenticacaoServiceImpl>();


            return serviceCollection;
        }

    }
}
