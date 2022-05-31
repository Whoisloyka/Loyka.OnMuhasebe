using System;
using System.Collections.Generic;
using System.Text;
using Loyka.OnMuhasebe.CommonDtos;
using Loyka.OnMuhasebe.Services;

namespace Loyka.OnMuhasebe.Donemler;
public interface IDonemAppService : ICrudAppService<SelectDonemDto, ListDonemDto,
    DonemListParameterDto, CreateDonemDto, UpdateDonemDto, CodeParameterDto>
{
}