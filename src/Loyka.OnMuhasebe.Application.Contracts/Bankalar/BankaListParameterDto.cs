using System;
using System.Collections.Generic;
using System.Text;
using Loyka.OnMuhasebe.CommonDtos;
using Volo.Abp.Application.Dtos;

namespace Loyka.OnMuhasebe.Bankalar;
public class BankaListParameterDto : PagedResultRequestDto, IEntityDto, IDurum
{
    public bool Durum { get; set; }
}
