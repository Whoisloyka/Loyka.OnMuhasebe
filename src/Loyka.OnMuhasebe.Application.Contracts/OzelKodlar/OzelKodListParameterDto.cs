﻿using Loyka.OnMuhasebe.CommonDtos;
using Volo.Abp.Application.Dtos;

namespace Loyka.OnMuhasebe.OzelKodlar;

public class OzelKodListParameterDto : PagedResultRequestDto, IDurum, IEntityDto
{
    public OzelKodTuru KodTuru { get; set; }
    public KartTuru KartTuru { get; set; }
    public bool Durum { get; set; }
}