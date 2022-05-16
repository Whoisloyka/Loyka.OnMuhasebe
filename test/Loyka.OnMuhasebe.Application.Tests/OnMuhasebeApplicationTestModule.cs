using Volo.Abp.Modularity;

namespace Loyka.OnMuhasebe;

[DependsOn(
    typeof(OnMuhasebeApplicationModule),
    typeof(OnMuhasebeDomainTestModule)
    )]
public class OnMuhasebeApplicationTestModule : AbpModule
{

}
