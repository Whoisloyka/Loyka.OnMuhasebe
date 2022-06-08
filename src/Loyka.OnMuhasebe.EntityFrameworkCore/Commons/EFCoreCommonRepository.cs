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
public class EfCoreCommonRepository<TEntity> : EfCoreRepository<OnMuhasebeDbContext, TEntity, Guid>,
    ICommonRepository<TEntity> where TEntity : class, IEntity<Guid>
{
    public EfCoreCommonRepository(IDbContextProvider<OnMuhasebeDbContext> dbContextProvider) : base(dbContextProvider)
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
        var queryable = await WithDetailsAsync(includeProperties);

        if (predicate != null)
            queryable = queryable.Where(predicate);

        if (orderBy != null)
            queryable = queryable.OrderByDescending(orderBy);

        return await queryable
            .Skip(skipCount)
            .Take(maxResultCount)
            .ToListAsync();
    }
    public async Task<string> GetCodeAsync(Expression<Func<TEntity, string>> propertySelector,
        Expression<Func<TEntity, bool>> predicate = null) // Örn: code = banka-0004
    {
        // Yeni oluşturulacak olan kartın aktif/pasif durumuna ve şubesine göre yeni kod oluşturur. 
        static string CreateNewCode(string code) 
        {
            var number = "";

            foreach (var character in code) // Gelen string içinde karakter karakter gezinir ve sayısal veri olanı number içine atar. banka-004ü 004 olarak alır number'a atar.
            { 
                if (char.IsDigit(character))
                    number += character;
                else
                    number = "";
            }

            var newNumber = number == "" ? "1" : (long.Parse(number) + 1).ToString(); // numberı 1 arttırdıktan sonra başına char karakterleri eklemek için geri stringe çeviriyoruz.
            var difference = code.Length - newNumber.Length;
            if(difference < 0)
                difference = 0; // farkı 0dan küçükse 0 a eşitledik çünkü 999dan 1000e geçince fark -1 e düşüp hata vermemesi lazım. 

            var newCode = code.Substring(0, difference);
            newCode += newNumber;

            return newCode;
        }

        var dbSet = await GetDbSetAsync(); // dbSet'e atanan Entity içinde sorgu yapmamızı sağlar.
        var maxCode = predicate == null ?
            await dbSet.MaxAsync(propertySelector) : // Eğer predicatein içinde bir filtre yoksa propertySelector ile entity'nin hanig propertysini gönderdiysek onun içinde max değeri getirir.
            await dbSet.Where(predicate).MaxAsync(propertySelector); // Önce predicate filtresini uygular daha sonra elde edilen propertynin max değerini alır.
        return maxCode == null ? "0000000000000001" : CreateNewCode(maxCode);
    }
    public async Task<IList<TEntity>> FromSqlRawAsync(string sql, params object[] parameters)
    {
        var context = await GetDbContextAsync();
        return await context.Set<TEntity>().FromSqlRaw(sql, parameters).ToListAsync();
    }
    public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate = null)
    {
        var dbSet = await GetDbSetAsync();
        return predicate == null ? await dbSet.AnyAsync() : await dbSet.AnyAsync(predicate);
    }

    public async Task<List<TEntity>> GetPagedListAsync<TKey>(int skipCount, int maxResultCount, Expression<Func<TEntity, bool>> predicate = null, Expression<Func<TEntity, TKey>> orderBy = null, params Expression<Func<TEntity, object>>[] includeProperties)
    {
        var queryable = await WithDetailsAsync(includeProperties);

        if (predicate != null)
            queryable = queryable.Where(predicate);

        if (orderBy != null)
            queryable = queryable.OrderBy(orderBy);

        return await queryable
            .Skip(skipCount)
            .Take(maxResultCount)
            .ToListAsync();
    }
}
