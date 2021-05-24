using HotelListing.Core.DataAccess.Repositories.Interfaces;
using HotelListing.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelListing.Core.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CoreDatabaseContext _coreContext;
        IGenericRepository<Country> _countries;
        IGenericRepository<Hotel> _hotels;

        public UnitOfWork(CoreDatabaseContext coreContext)
        {
            _coreContext = coreContext;
        }

        public IGenericRepository<Country> Countries => _countries ??= new GenericRepository<Country>(_coreContext);
        public IGenericRepository<Hotel> Hotels => _hotels ??= new GenericRepository<Hotel>(_coreContext);

        public void Dispose()
        {
            _coreContext.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _coreContext.SaveChangesAsync();
        }
    }
}
