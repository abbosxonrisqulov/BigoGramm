using System.Linq.Expressions;

namespace BigoGramm.DAL.IRepositories;

public interface IRepository<T> where T : class
{
    Task CreateAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task<T> GetAsync(Expression<Func<T, bool>> expression, string[] includes = null);
    IQueryable<T> GetAll(Expression<Func<T, bool>> expression = null, bool isNotTraced = true, string[] includes = null);
    Task SaveChanges();
}
