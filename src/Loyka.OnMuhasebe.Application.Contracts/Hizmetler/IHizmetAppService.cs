using System;
using System.Collections.Generic;
using System.Text;
using Loyka.OnMuhasebe.CommonDtos;
using Loyka.OnMuhasebe.Services;

namespace Loyka.OnMuhasebe.Hizmetler;
public interface IHizmetAppService : ICrudAppService<SelectHizmetDto, ListHizmetDto,
    HizmetListParameterDto, CreateHizmetDto, UpdateHizmetDto, CodeParameterDto>
{
}