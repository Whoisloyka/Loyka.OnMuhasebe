using System;
using System.Collections.Generic;
using System.Text;
using Loyka.OnMuhasebe.CommonDtos;
using Volo.Abp.Application.Dtos;

namespace Loyka.OnMuhasebe.BankaSubeler;
public class BankaSubeListParameterDto : PagedResultRequestDto, IDurum, IEntityDto
{
    // Hangi bankanın şubelerini listeleyecğimizi bankaId'den alacağız.
    public Guid BankaId { get; set; }
    public bool Durum { get; set; }
}
