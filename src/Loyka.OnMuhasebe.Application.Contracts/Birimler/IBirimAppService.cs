using System;
using System.Collections.Generic;
using System.Text;
using Loyka.OnMuhasebe.CommonDtos;
using Loyka.OnMuhasebe.Services;

namespace Loyka.OnMuhasebe.Birimler;
public interface IBirimAppService : ICrudAppService<SelectBirimDto, ListBirimDto,
    BirimListParameterDto, CreateBirimDto, UpdateBirimDto, CodeParameterDto>
{
}