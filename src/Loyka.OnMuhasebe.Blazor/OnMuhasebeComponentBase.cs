using Loyka.OnMuhasebe.Localization;
using Volo.Abp.AspNetCore.Components;

namespace Loyka.OnMuhasebe.Blazor;

public abstract class OnMuhasebeComponentBase : AbpComponentBase
{
    protected OnMuhasebeComponentBase()
    {
        LocalizationResource = typeof(OnMuhasebeResource);
    }
}
