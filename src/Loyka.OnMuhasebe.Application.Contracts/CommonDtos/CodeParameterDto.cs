using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;



// BankaHesapKodParameterDto'da hem sube id hem durum bilgisi isteniyor.
// Fakat bazı dto'larımızda sadece durum üzerinden filtreleme yapıcaz.
// böyle ekstra properylere ihtiyaç olmayan dto'larda buradan kalıtım alıcaz.
namespace Loyka.OnMuhasebe.CommonDtos;
public class CodeParameterDto : IDurum, IEntityDto
{
    public bool Durum { get; set; }
}
