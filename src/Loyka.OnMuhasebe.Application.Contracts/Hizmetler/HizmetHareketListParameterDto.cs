using System;
using Loyka.OnMuhasebe.CommonDtos;
using Loyka.OnMuhasebe.Faturalar;
using Volo.Abp.Application.Dtos;

namespace Loyka.OnMuhasebe.Hizmetler;

public class HizmetHareketListParameterDto: PagedResultRequestDto, IDurum, IEntityDto
{
    public Guid HizmetId { get; set; }
    public FaturaHareketTuru HareketTuru { get; set; }
    public Guid SubeId { get; set; }
    public Guid DonemId { get; set; }
    public bool Durum { get; set; }
}