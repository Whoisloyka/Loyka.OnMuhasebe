using System;
using System.Collections.Generic;
using System.Text;
using Loyka.OnMuhasebe.CommonDtos;
using Volo.Abp.Application.Dtos;



// BankaSube kodunu oluştururken sadece duruma göre değil aynı zamanda
// bankaId'ye de ihtiyacımız olduğu için bu sınıfı yazıyoruz. 
namespace Loyka.OnMuhasebe.BankaSubeler;
public class BankaSubeCodeParameterDto : IDurum, IEntityDto
{
    public Guid BankaId { get; set; }
    public bool Durum { get; set; }
}
