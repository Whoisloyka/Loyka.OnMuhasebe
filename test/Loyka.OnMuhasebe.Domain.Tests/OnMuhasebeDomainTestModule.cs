using Loyka.OnMuhasebe.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Loyka.OnMuhasebe;

[DependsOn(
    typeof(OnMuhasebeEntityFrameworkCoreTestModule)
    )]
public class OnMuhasebeDomainTestModule : AbpModule
{

}
