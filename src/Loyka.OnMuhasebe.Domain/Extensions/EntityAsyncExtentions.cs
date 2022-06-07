using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using IdentityModel;
using Loyka.OnMuhasebe.Exceptions;
using Volo.Abp.Domain.Repositories;

namespace Loyka.OnMuhasebe.Extensions;
public static class EntityAsyncExtentions
{
    public static async Task KodAnyAsync<TEntity>(this IReadOnlyRepository<TEntity> repository,
        string kod, Expression<Func<TEntity, bool>> predicate, bool check=true)
        where TEntity : class, IEntity
    {
        if (check && await repository.AnyAsync(predicate))
            throw new DuplicateCodeException(kod);
    }
    public static async Task EntityAnyAsync<TEntity>(this IReadOnlyRepository<TEntity> repository,
    object id, Expression<Func<TEntity, bool>> predicate, bool check = true)
        where TEntity : class, IEntity
    {
        if (check && id != null)
        {
            var anyAsync = await repository.AnyAsync(predicate); // İstenilen entity'i bul getir.

            if(!anyAsync)// eğer entity null dönüyor ise.
                throw new EntityNotFoundException(typeof(TEntity),id);        
        }
    }

    public static async Task EntityAnyAsync(this IReadOnlyRepository<OzelKod> repository,
        Guid? id, OzelKodTuru kodTuru, KartTuru kartTuru,bool check=true)
    {
        if (check && id != null)
        {
            var anyAsync = await repository.AnyAsync(x => x.Id == id &&
                                                     x.KodTuru == kodTuru &&
                                                     x.KartTuru == kartTuru);

            if (!anyAsync)
                throw new EntityNotFoundException(typeof(OzelKod), id);
        }
    }
    public static async Task RelationalEntityAsync<TEntity>(this IReadOnlyRepository<TEntity> repository,
        Expression<Func<TEntity, bool>> predicate)
        where TEntity : class, IEntity
    {
        var anyAsync = await repository.AnyAsync(predicate);

        if (anyAsync)
            throw new CannotBeDeletedException();
    }
}
