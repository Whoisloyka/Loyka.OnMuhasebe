using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Loyka.OnMuhasebe.EntityFrameworkCore;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Loyka.OnMuhasebe.Commons;
public class EFCoreCommonRepository<TEntity> : EfCoreRepository<OnMuhasebeDbContext, TEntity, Guid>,
    ICommonRepository<TEntity> where TEntity : class, IEntity<Guid>
{
    public EFCoreCommonRepository(IDbContextProvider<OnMuhasebeDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    // Functionlar TASK olduğu için async koymamız lazım.

    public async Task<TEntity> GetAsync(object id, Expression<Func<TEntity, bool>> predicate = null,
        params Expression<Func<TEntity, object>>[] includeProperties)
    {
        // queryable = string halde ki "SELECT * FROM dbo.x" şeklindedir. Biz bunun kalan kısmını doldururuz ve DB'de sorguyu çalıştırıp geriye değer döndürürüz. 
        var queryable = await WithDetailsAsync(includeProperties); // WithDetailAsync ile dataları db'den getirirken navigation property'leri de dolu getir demek.
                                                                   // Aslında SQL Query'lerdeki Join'in aynısıdır.

        TEntity entity;

        if(predicate != null)
        {
            entity = await queryable.FirstOrDefaultAsync(predicate);
            if (entity == null)
                throw new EntityNotFoundException(typeof(TEntity), id); // Şu tipteki entitynin şu id'li değeri bulunamadı diye hata mesajı verir.
            return entity;
        }

        entity = await queryable.FirstOrDefaultAsync();
        if (entity == null)
            throw new EntityNotFoundException(typeof(TEntity), id);
        return entity;
    }
    public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate = null, 
        params Expression<Func<TEntity, object>>[] includeProperties)
    // Db'de id'le alakalı bir entity bulunamadığı zaman hata mesajı vermesin diye kullanıcaz.
    {
        var queryable = await WithDetailsAsync(includeProperties);

        if(predicate != null)
            return await queryable.FirstOrDefaultAsync(predicate);

        return await queryable.FirstOrDefaultAsync();
    }
    public async Task<TEntity> GetAsync(object id, Expression<Func<TEntity, bool>> predicate = null)
    {
        var queryable = await WithDetailsAsync(); // Navigation property parametrisi almamasına rağmen bu kısmı yazmamızın sebebi:
                                                  // zaten ICollection tipinde ilişkileri olan entityleri çağırmak için kullanacak olmamızdır. Collection tipindeki verileri dolu getirecektir.
        TEntity entity;

        if(predicate != null)
        {
            entity = await queryable.FirstOrDefaultAsync(predicate);
            if (entity == null)
                throw new EntityNotFoundException(typeof(TEntity), id);
            return entity;
        }
        entity= await queryable.FirstOrDefaultAsync();
        if(entity == null)
            throw new EntityNotFoundException(typeof(TEntity), id);
        return entity;
    }
    public async Task<List<TEntity>> GetPagedListAsync(int skipCount, int maxResultCount,
    Expression<Func<TEntity, bool>> predicate = null,
    Expression<Func<TEntity, IKey>> orderBy = null,
    params Expression<Func<TEntity, object>>[] includeProperties)
    {
        // queryable string bir sql sorgusudur. İçi doldurmadan gidip çalışmaz
        var queryable = await WithDetailsAsync(includeProperties); // SELECT * FROM dbo.EntityTableName

        if (predicate != null)// Burdan sonrası queryable sorgusunun içini doldurmak için.
            queryable = queryable.Where(predicate); // SELECT * FROM dbo.EntityTableName WHERE id>5   ===> predicate id>5 gibi bir filtre olsun.

        if(orderBy != null)
            queryable = queryable.OrderBy(orderBy);

        return await queryable
            .Take(maxResultCount)
            .Skip(skipCount)
            .ToListAsync(); // Tamamlanın queryable sorgusunu DB'ye gönderir, sorgular ve listeleyip getirir.
    }
    public async Task<List<TEntity>> GetPagedLastListAsync<TKey>(int skipCount, int maxResultCount,
        Expression<Func<TEntity, bool>> predicate = null,
        Expression<Func<TEntity, TKey>> orderBy = null,
        params Expression<Func<TEntity, object>>[] includeProperties)
    {
        
    }





    /************************************************************************************************************/





    public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate = null)
    {
        throw new NotImplementedException();
    }
    public Task<IList<TEntity>> FromSqlRawAsync(string sql, params object[] parameters)
    {
        throw new NotImplementedException();
    }






    public Task<string> GetCodeAsync(Expression<Func<TEntity, string>> propertySelector, Expression<Func<TEntity, bool>> predicate = null)
    {
        throw new NotImplementedException();
    }




}
