using Microsoft.EntityFrameworkCore;
using PomeloSoftCase.Application.Interfaces.Repositories;
using PomeloSoftCase.Domain.Common;
using PomeloSoftCase.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PomeloSoftCase.Persistence.Concrete.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly BlogDbContext _blogDbContext;
        public Repository(BlogDbContext blogDbContext)
        {
            _blogDbContext = blogDbContext;
        }
        public DbSet<T> Table => _blogDbContext.Set<T>();
        public async Task<bool> AddAsync(T model)
        {
            await Table.AddAsync(model);
            return await SaveChangesAsync();
        }
        public async Task<List<T>> GetAllInclude(string tableName, Expression<Func<T, bool>> filter = null)
            => await Table.Include(tableName).AsNoTracking().Where(filter).ToListAsync();
        public async Task<T> GetInclude(string tableName, Expression<Func<T, bool>> filter = null)
            => await Table.Include(tableName).AsNoTracking().FirstOrDefaultAsync(filter);
        public async Task<List<T>> GetAllAsync()
            => await Table.AsNoTracking().ToListAsync();

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter)
            => await Table.Where(filter).AsNoTracking().ToListAsync();

        public async Task<T> GetAsync(Expression<Func<T, bool>> filter)
            => await Table.AsNoTracking().FirstOrDefaultAsync(filter);

        public async Task<T> GetByIdAsync(int Id)
            => await Table.FindAsync(Id);

        public async Task<bool> UpdateAsync(T model)
        {
            Table.Update(model);
            return await SaveChangesAsync();
        }
        public async Task<bool> SaveChangesAsync()
            => await _blogDbContext.SaveChangesAsync() >= 1 ? true : false;
    }
}
