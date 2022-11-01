using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Sevices
{
    public interface IService <T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        IQueryable<T> GetAll(Expression<Func<T, bool>> expression); //IQueryable yanlış olan sorgular direkt veri tabanına gitmez tolistAsync methodunu çağırırsak o zaman gider

        //productreposity.where(x=>a.id<5).orderby.TolistAsync(); // T=x, id<5 =bool olarak karşılık gelir
        Task<IEnumerable<T>> GetAllAsync(); 
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression); //IQueryable yanlış olan sorgular direkt veri tabanına gitmez tolistAsync methodunu çağırırsak o zaman gider

        Task AddAsync(T entity); // Async= Uzun süren işlerde bekletme olayı olamamsı için yapılır. Bloklama yapmaz yani
        Task AddRangeAsync(IEnumerable<T> entities);
        Task UpdateAsync(T entity);  // veritabanında değişiklik olması için async kullanıldı
        Task DeleteAsync(T entity);  
        Task RemoveAsync(T entity);
        Task RemoveRangeAsync(IEnumerable<T> entities);

    }
}
