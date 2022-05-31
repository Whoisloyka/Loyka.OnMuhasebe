using System;
using System.Collections.Generic;
using System.Text;
using Loyka.OnMuhasebe.Services;

namespace Loyka.OnMuhasebe.Kasalar;
public interface IKasaAppService : ICrudAppService<SelectKasaDto, ListKasaDto,
    KasaListParameterDto, CreateKasaDto, UpdateKasaDto, KasaCodeParameterDto>
{
}