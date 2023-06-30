using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dotnet_CRUD.Domain.Repository.Interfaces
{
    public interface IDBUnitOfWork : IDisposable
    {
        contact_DBContext DBContext { get; } // to call database
        void Commit();
    }
}