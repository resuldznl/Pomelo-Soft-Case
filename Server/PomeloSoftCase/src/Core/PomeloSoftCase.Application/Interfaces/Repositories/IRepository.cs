using PomeloSoftCase.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PomeloSoftCase.Application.Interfaces.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<T> GetAsync(Expression<Func<T, bool>> filter);
        Task<T> GetByIdAsync(int Id);
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> filter);
        Task<bool> AddAsync(T model);
        Task<bool> UpdateAsync(T model);
        Task<bool> SaveChangesAsync();
        Task<List<T>> GetAllInclude(string tableName, Expression<Func<T, bool>> filter = null);
        Task<T> GetInclude(string tableName, Expression<Func<T, bool>> filter = null);
    }
}
