using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Loyka.OnMuhasebe.Services;

namespace Loyka.OnMuhasebe.Parametreler;
public interface IFirmaParametreAppService : ICrudAppService<SelectFirmaParametreDto,
    SelectFirmaParametreDto, FirmaParametreListParameterDto, CreateFirmaParametreDto,
    UpdateFirmaParametreDto>
{
    //Task<bool> UserAnyAsync(Guid userId);
}