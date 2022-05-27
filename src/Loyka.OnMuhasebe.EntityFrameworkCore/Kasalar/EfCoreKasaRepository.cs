using Loyka.OnMuhasebe.Commons;
using Loyka.OnMuhasebe.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Loyka.OnMuhasebe.Kasalar;

public class EfCoreKasaRepository : EfCoreCommonRepository<Kasa>, IKasaRepository
{
    public EfCoreKasaRepository(IDbContextProvider<OnMuhasebeDbContext> dbContextProvider) 
        : base(dbContextProvider)
    {
    }
}