using Loyka.OnMuhasebe.Commons;
using Loyka.OnMuhasebe.EntityFrameworkCore;
using Loyka.OnMuhasebe.Faturalar;
using Volo.Abp.EntityFrameworkCore;

namespace Loyka.OnMuhasebe.FaturaHareketler;

public class EfCoreFaturaHareketRepository : EfCoreCommonRepository<FaturaHareket>, 
    IFaturaHareketRepository
{
    public EfCoreFaturaHareketRepository(IDbContextProvider<OnMuhasebeDbContext> dbContextProvider)
        : base(dbContextProvider)
    {
    }
}