using Loyka.OnMuhasebe.Commons;
using Loyka.OnMuhasebe.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Loyka.OnMuhasebe.OdemeBelgeleri;

public class EfCoreOdemeBelgesiRepository : EfCoreCommonRepository<OdemeBelgesi>, IOdemeBelgesiRepository
{
    public EfCoreOdemeBelgesiRepository(IDbContextProvider<OnMuhasebeDbContext> dbContextProvider) 
        : base(dbContextProvider)
    {        
    }
}