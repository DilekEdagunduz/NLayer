using System.Linq.Expressions;

namespace NLayer.Repository.Repositories
{
    public interface IGenericRepository<T> where T: class
    {
        Task<T> GetByIdAsync(int id);
        IQueryable<T> GetAll(); //IQueryable yanlış olan sorgular direkt veri tabanına gitmez tolistAsync methodunu çağırırsak o zaman gider

        //productreposity.where(x=>a.id<5).orderby.TolistAsync(); // T=x, id<5 =bool olarak karşılık gelir
        IQueryable<T> Where(Expression<Func<T,bool>>expression); //IQueryable yanlış olan sorgular direkt veri tabanına gitmez tolistAsync methodunu çağırırsak o zaman gider
        Task <bool>AnyAsync(Expression<Func<T, bool>> expression); 

        Task AddAsync(T entity); // Async= UZun süren işlerde bekletme olayı olamamsı için yapılır. Bloklama yapmaz yani
        Task AddRangeAsync(IEnumerable<T> entities);
        void Update(T entity); // Burada async gerek yok çünkü uzun işlemler yapılmaz
        void Delete(T entity); // Burada async gerek yok çünkü uzun işlemler yapılmaz
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);

    }
}
