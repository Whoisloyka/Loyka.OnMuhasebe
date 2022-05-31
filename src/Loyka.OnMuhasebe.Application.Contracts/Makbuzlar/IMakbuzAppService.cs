using System;
using System.Collections.Generic;
using System.Text;
using Loyka.OnMuhasebe.Kasalar;
using Loyka.OnMuhasebe.Services;

namespace Loyka.OnMuhasebe.Makbuzlar;
public interface IKasaAppService : ICrudAppService<SelectKasaDto, ListKasaDto,
    KasaListParameterDto, CreateKasaDto, UpdateKasaDto, KasaCodeParameterDto>
{
}