using Loyka.OnMuhasebe.CommonDtos;
using Volo.Abp.Application.Dtos;

namespace Loyka.OnMuhasebe.Cariler;

public class CariListParameterDto : PagedResultRequestDto, IDurum, IEntityDto
{
    public bool Durum { get; set; }
}