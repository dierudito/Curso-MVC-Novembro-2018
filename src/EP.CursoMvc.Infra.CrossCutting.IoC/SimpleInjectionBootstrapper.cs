using EP.CursoMvc.Application.Interfaces;
using EP.CursoMvc.Application.Services;
using EP.CursoMvc.Domain.Interfaces;
using EP.CursoMvc.Domain.Services;
using EP.CursoMvc.Infra.Data.Context;
using EP.CursoMvc.Infra.Data.Repository;
using EP.CursoMvc.Infra.Data.UoW;
using SimpleInjector;

namespace EP.CursoMvc.Infra.CrossCutting.IoC
{
    public class SimpleInjectionBootstrapper
    {
        // Lifestyle.Transient => Uma instancia para cada solicitacao;
        // Lifestyle.Singleton => Uma instancia unica para a classe (para o servidor)
        // Lifestyle.Scoped => Uma instancia unica para o request

        public static void Register(Container container)
        {
            // APP
            container.Register<IClienteAppService, ClienteAppService>(Lifestyle.Scoped);

            // Domain
            container.Register<IClienteService, ClienteService>(Lifestyle.Scoped);

            // Infra
            container.Register<IClienteRepository, ClienteRepository>(Lifestyle.Scoped);

            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<CursoMvcContext>(Lifestyle.Scoped);
        }
    }
}
