using System;
using System.Collections.Generic;
using System.Text;
using Loyka.OnMuhasebe.Services;

namespace Loyka.OnMuhasebe.OzelKodlar;
public interface IOzelKodAppService : ICrudAppService<SelectOzelKodDto, ListOzelKodDto,
    OzelKodListParameterDto, CreateOzelKodDto, UpdateOzelKodDto, OzelKodCodeParameterDto>
{
}