using Loyka.OnMuhasebe.Commons;
using Loyka.OnMuhasebe.EntityFrameworkCore;
using Loyka.OnMuhasebe.Makbuzlar;
using Volo.Abp.EntityFrameworkCore;

namespace Loyka.OnMuhasebe.MakbuzHareketler;

public class EfCoreMakbuzHareketRepository : EfCoreCommonRepository<MakbuzHareket>, IMakbuzHareketRepository
{
    public EfCoreMakbuzHareketRepository(IDbContextProvider<OnMuhasebeDbContext> dbContextProvider) 
        : base(dbContextProvider)
    {
    }
}