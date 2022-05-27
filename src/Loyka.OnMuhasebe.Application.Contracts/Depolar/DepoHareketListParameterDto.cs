using System;
using Loyka.OnMuhasebe.CommonDtos;
using Volo.Abp.Application.Dtos;

namespace Loyka.OnMuhasebe.Depolar;

public class DepoHareketListParameterDto : PagedResultRequestDto, IDurum, IEntityDto
{
    public Guid DepoId { get; set; }
    public Guid SubeId { get; set; }
    public Guid DonemId { get; set; }
    public bool Durum { get; set; }
}