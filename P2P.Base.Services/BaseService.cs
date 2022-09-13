using AutoMapper;
using Entities.Context;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace P2P.Base.Services
{
    public class BaseService
    {
        protected readonly MainContext _context;
        protected readonly IMapper _mapper;

        public BaseService(MainContext context)
        {
            _context = context;
        }

        public BaseService(MainContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        protected async Task SaveContextChangesAsync(IDbContextTransaction dbContextTransaction = null)
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                if (dbContextTransaction != null)
                {
                    dbContextTransaction.Rollback();
                }

                throw new Exception(e.Message);
            }
        }
    }
}
