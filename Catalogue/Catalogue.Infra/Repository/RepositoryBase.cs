using Catalogue.Core.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Catalogue.Infra
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T:class
    {
        private CatalogueContext _context { get; set; }
        public RepositoryBase(CatalogueContext context)
        {
            _context = context;
        }

        public async  Task<IList<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async  Task<T> GetByCodition(Expression<Func<T,bool>> expression)
        {
            return await _context.Set<T>().Where(expression).FirstOrDefaultAsync(); 
        }

        public async Task Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public async Task Update(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry<T>(entity).State = EntityState.Modified;
        }
    }
}
