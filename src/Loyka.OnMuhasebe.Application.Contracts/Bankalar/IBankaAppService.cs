using System;
using System.Collections.Generic;
using System.Text;
using Loyka.OnMuhasebe.CommonDtos;
using Loyka.OnMuhasebe.Services;

namespace Loyka.OnMuhasebe.Bankalar;
public interface IBankaAppService : ICrudAppService<SelectBankaDto, ListBankaDto, BankaListParameterDto,
    CreateBankaDto, UpdateBankaDto, CodeParameterDto>
{
}
