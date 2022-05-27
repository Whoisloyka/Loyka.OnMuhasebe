using System;
using System.Collections.Generic;
using System.Text;



// Daha sonradam IDurum interfacesini filtrelemek sınıflandırmak için kullanacağız.
// Class'a gelecek olan dto ları burayı kullanarak sınıflandırabiliriz.
// Parametrelerdeki işlemlerimizi kolaylaştırmak için kullanacağız.
// Create ve update gibi işlemlerin olduğu sınıflar için kullanmayacağız.
namespace Loyka.OnMuhasebe.CommonDtos;
public interface IDurum
{
    public bool Durum { get; set; }
}
