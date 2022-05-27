using Loyka.OnMuhasebe.CommonDtos;
using Volo.Abp.Application.Dtos;

namespace Loyka.OnMuhasebe.Stoklar;

public class StokListParameterDto : PagedResultRequestDto, IDurum, IEntityDto
{
    public bool Durum { get; set; }
}