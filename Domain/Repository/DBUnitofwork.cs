using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Dotnet_CRUD.Domain.Repository.Interfaces;

namespace Dotnet_CRUD.Domain.Repository
{
    public class DBUnitofwork : IDBUnitOfWork
    {
        public bool disposed = false;
        public readonly contact_DBContext _context;
        public DBUnitofwork(contact_DBContext context)
        {
            _context = context;
        }

        public contact_DBContext DBContext
        {
            get
            {
                return _context;
            }
        }

        #region [Begin, Commit and Rollback Transaction]

        public void Commit()
        {
            try
            {
                _context.SaveChanges();

            }
            catch (ValidationException vexp)
            {
                foreach (var exp in vexp.Data.Values)
                {
                    string? error = exp.ToString();
                    Console.WriteLine(error);
                }
            }
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        #endregion



    }
}


