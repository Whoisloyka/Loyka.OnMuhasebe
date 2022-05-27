using Loyka.OnMuhasebe.BankaSubeler;
using Loyka.OnMuhasebe.Commons;
using Loyka.OnMuhasebe.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Loyka.OnMuhasebe.Birimler;

public class EfCoreBirimRepository : EfCoreCommonRepository<Birim>, IBirimRepository
{
    public EfCoreBirimRepository(IDbContextProvider<OnMuhasebeDbContext> dbContextProvider)
        : base(dbContextProvider)
    {
    }
}