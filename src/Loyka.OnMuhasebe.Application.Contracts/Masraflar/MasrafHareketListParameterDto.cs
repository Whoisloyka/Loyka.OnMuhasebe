using System;
using Loyka.OnMuhasebe.CommonDtos;
using Loyka.OnMuhasebe.Faturalar;
using Volo.Abp.Application.Dtos;

namespace Loyka.OnMuhasebe.Masraflar;

public class MasrafHareketListParameterDto : PagedResultRequestDto, IDurum, IEntityDto
{
    public Guid MasrafId { get; set; }
    public FaturaHareketTuru HareketTuru { get; set; }
    public Guid SubeId { get; set; }
    public Guid DonemId { get; set; }
    public bool Durum { get; set; }
}