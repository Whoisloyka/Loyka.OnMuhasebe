using System;
using System.Collections.Generic;
using System.Text;
using Loyka.OnMuhasebe.Services;

namespace Loyka.OnMuhasebe.BankaSubeler;
public interface IBankaSubeAppService : ICrudAppService<SelectBankaSubeDto, ListBankaSubeDto,
    BankaSubeListParameterDto, CreateBankaSubeDto,
    UpdateBankaSubeDto, BankaSubeCodeParameterDto>
{
}