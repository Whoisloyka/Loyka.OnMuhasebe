using Loyka.OnMuhasebe.Commons;
using Loyka.OnMuhasebe.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Loyka.OnMuhasebe.Raporlar;

public class EfCoreGirenCikanBakiyeRepository : EfCoreCommonNoKeyRepository<GirenCikanBakiye>,
    IGirenCikanBakiyeRepository
{
    public EfCoreGirenCikanBakiyeRepository(IDbContextProvider<OnMuhasebeDbContext> dbContextProvider) 
        : base(dbContextProvider)
    {
    }
}