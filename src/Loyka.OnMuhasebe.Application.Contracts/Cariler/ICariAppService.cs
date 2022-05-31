using System;
using System.Collections.Generic;
using System.Text;
using Loyka.OnMuhasebe.CommonDtos;
using Loyka.OnMuhasebe.Services;

namespace Loyka.OnMuhasebe.Cariler;
public interface ICariAppService : ICrudAppService<SelectCariDto, ListCariDto,
    CariListParameterDto, CreateCariDto, UpdateCariDto, CodeParameterDto>
{
}