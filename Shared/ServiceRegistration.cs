using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dotnet_CRUD.Domain.Repository;
using Dotnet_CRUD.Shared.ResponseDataHandler;
using DotnetMyCrud.Infrastructure.ContactRepo;

namespace DotnetMyCrud.Shared
{
    public static class ServiceRegistration
    {
        public static void Contact(this IServiceCollection services)
        {
            services.AddTransient<IContactRepository, ContactRepository>();
        }

        public static void Response(this IServiceCollection services)
        {
            services.AddSingleton<IResponseHandler, ResponseDataHandler>();
        }
        public static void UnilOfWork(this IServiceCollection services)
        {
            services.AddScoped<IDBUnitOfWork, DBUnitofwork>();
        }

    }
}