using System;
using System.Collections.Generic;
using System.Text;



// BankaSube kodunu oluştururken sadece duruma göre değil aynı zamanda
// bankaId'ye de ihtiyacımız olduğu için bu sınıfı yazıyoruz. 
namespace Loyka.OnMuhasebe.BankaSubeler;
public class BankaSubeCodeParameterDto
{
    public Guid BankaId { get; set; }
    public bool Durum { get; set; }
}
