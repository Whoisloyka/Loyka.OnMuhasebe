using System;
using System.Collections.Generic;
using System.Text;
using Loyka.OnMuhasebe.Services;

namespace Loyka.OnMuhasebe.Faturalar;
public interface IFaturaAppService : ICrudAppService<SelectFaturaDto, ListFaturaDto,
    FaturaListParameterDto, CreateFaturaDto, UpdateFaturaDto, FaturaNoParameterDto>
{
}