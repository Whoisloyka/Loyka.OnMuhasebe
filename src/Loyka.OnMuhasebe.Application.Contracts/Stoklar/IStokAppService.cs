using System;
using System.Collections.Generic;
using System.Text;
using Loyka.OnMuhasebe.CommonDtos;
using Loyka.OnMuhasebe.Services;

namespace Loyka.OnMuhasebe.Stoklar;
public interface IStokAppService : ICrudAppService<SelectStokDto, ListStokDto,
    StokListParameterDto, CreateStokDto, UpdateStokDto, CodeParameterDto>
{
}