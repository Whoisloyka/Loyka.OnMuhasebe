using System;
using System.Collections.Generic;
using System.Text;
using Loyka.OnMuhasebe.CommonDtos;
using Loyka.OnMuhasebe.Services;
using Loyka.OnMuhasebe.Stoklar;

namespace Loyka.OnMuhasebe.Subeler;
public interface IStokAppService : ICrudAppService<SelectStokDto, ListStokDto,
    StokListParameterDto, CreateStokDto, UpdateStokDto, CodeParameterDto>
{
}