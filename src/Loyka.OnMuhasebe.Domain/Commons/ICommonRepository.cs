using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Volo.Abp.Domain.Repositories;

namespace Loyka.OnMuhasebe.Commons;
public interface ICommonRepository<TEntity> : IRepository<TEntity,Guid>
    where TEntity : class, IEntity<Guid>
{
    //Expression<Func<TEntity, bool>> predicate=null gönderilen TEntity üzerinde çeşitli sorgu ve filtreleme yapmak için kullanılır.
    //Predicate defaultu null olduğu için istenmediği zaman kullanılmayabilir.
    Task<TEntity> GetAsync(object id, Expression<Func<TEntity, bool>> predicate = null,
        params Expression<Func<TEntity, object>>[] includeProperties); // İsteğe bağlı navigation property eklenebilir demek.

    //Yukarıdakiyle farkı object id yok. Yukarıdakinde gönderilen id DB'de bulunamazsa bu id yoktur diye hata mesajı verir.
    //Ancak bazen bu mesajın döndürülmesini istemeyiz.
    //Örneğin program ilk yüklendiğinde db'ye gidip bir id bulamayacak burda hata vermesini engellememiz lazım burda da id göndermediğimiz için bulamayınca hata vermez.
    Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate = null,
    params Expression<Func<TEntity, object>>[] includeProperties);


    Task<TEntity> GetAsync(object id, Expression<Func<TEntity, bool>> predicate = null);// Navigation property'si olmayan entitylerde kullanılır.




    /************Veri Sayfada Listelemek için  Oluşturulan Functionlar****************/
    /* skipCount = kaç adet veri atlanarak alınacak
     * maxResultCount = Kaç adet veri getirilecek */
    Task<List<TEntity>> GetPagedListAsync(int skipCount, int maxResultCount,
        Expression<Func<TEntity, bool>> predicate = null,
        Expression<Func<TEntity, IKey>> orderBy = null,
        params Expression<Func<TEntity, object>>[] includeProperties);

    Task<List<TEntity>> GetPagedLastListAsync<TKey>(int skipCount, int maxResultCount,
    Expression<Func<TEntity, bool>> predicate = null,
    Expression<Func<TEntity, TKey>> orderBy = null,
    params Expression<Func<TEntity, object>>[] includeProperties);

    Task<string> GetCodeAsync(Expression<Func<TEntity, string>> propertySelector,
        Expression<Func<TEntity, bool>> predicate = null);

    Task<IList<TEntity>> FromSqlRawAsync(string sql, params object[] parameters);

    Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate = null);
}