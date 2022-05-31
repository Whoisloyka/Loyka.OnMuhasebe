using System;
using System.Collections.Generic;
using System.Text;
using Loyka.OnMuhasebe.CommonDtos;
using Loyka.OnMuhasebe.Services;

namespace Loyka.OnMuhasebe.Masraflar;
public interface IMasrafAppService : ICrudAppService<SelectMasrafDto, ListMasrafDto,
    MasrafListParameterDto, CreateMasrafDto, UpdateMasrafDto, CodeParameterDto>
{
}