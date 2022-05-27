using System;
using System.Collections.Generic;
using System.Text;

namespace Loyka.OnMuhasebe.CommonDtos;
public interface IOzelKod
{
    public string OzelKod1Adi { get; set; }
    public Guid? OzelKod1Id { get; set; }
    public string OzelKod2Adi { get; set; }
    public Guid? OzelKod2Id { get; set; }
}
