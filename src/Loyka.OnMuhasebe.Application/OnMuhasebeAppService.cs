using System;
using System.Collections.Generic;
using System.Text;
using Loyka.OnMuhasebe.Localization;
using Volo.Abp.Application.Services;

namespace Loyka.OnMuhasebe;

/* Inherit your application services from this class.
 */
public abstract class OnMuhasebeAppService : ApplicationService
{
    protected OnMuhasebeAppService()
    {
        LocalizationResource = typeof(OnMuhasebeResource);
    }
}
