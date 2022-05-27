using Loyka.OnMuhasebe.Commons;
using Loyka.OnMuhasebe.OdemeBelgeleri;
using Loyka.OnMuhasebe.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System;
using System.Threading;
using System.Collections.Generic;
using Microsoft.AspNetCore.DataProtection.KeyManagement;

namespace Loyka.OnMuhasebe.Raporlar;

public class EfCoreOdemeBelgesiRepository : EfCoreCommonNoKeyRepository<OdemeBelgesi>,
    IOdemeBelgesiRepository
{
    public EfCoreOdemeBelgesiRepository(IDbContextProvider<OnMuhasebeDbContext> dbContextProvider) 
        : base(dbContextProvider)
    {
    }

    public Task<bool> AnyAsync(Expression<Func<OdemeBelgesi, bool>> predicate = null)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Guid id, bool autoSave = false, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteManyAsync(IEnumerable<Guid> ids, bool autoSave = false, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<OdemeBelgesi> FindAsync(Guid id, bool includeDetails = true, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<OdemeBelgesi> GetAsync(object id, Expression<Func<OdemeBelgesi, bool>> predicate = null, params Expression<Func<OdemeBelgesi, object>>[] includeProperties)
    {
        throw new NotImplementedException();
    }

    public Task<OdemeBelgesi> GetAsync(Expression<Func<OdemeBelgesi, bool>> predicate = null, params Expression<Func<OdemeBelgesi, object>>[] includeProperties)
    {
        throw new NotImplementedException();
    }

    public Task<OdemeBelgesi> GetAsync(object id, Expression<Func<OdemeBelgesi, bool>> predicate = null)
    {
        throw new NotImplementedException();
    }

    public Task<OdemeBelgesi> GetAsync(Guid id, bool includeDetails = true, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<string> GetCodeAsync(Expression<Func<OdemeBelgesi, string>> propertySelector, Expression<Func<OdemeBelgesi, bool>> predicate = null)
    {
        throw new NotImplementedException();
    }

    public Task<List<OdemeBelgesi>> GetPagedLastListAsync<TKey>(int skipCount, int maxResultCount, Expression<Func<OdemeBelgesi, bool>> predicate = null, Expression<Func<OdemeBelgesi, TKey>> orderBy = null, params Expression<Func<OdemeBelgesi, object>>[] includeProperties)
    {
        throw new NotImplementedException();
    }

    public Task<List<OdemeBelgesi>> GetPagedListAsync(int skipCount, int maxResultCount, Expression<Func<OdemeBelgesi, bool>> predicate = null, Expression<Func<OdemeBelgesi, IKey>> orderBy = null, params Expression<Func<OdemeBelgesi, object>>[] includeProperties)
    {
        throw new NotImplementedException();
    }
}