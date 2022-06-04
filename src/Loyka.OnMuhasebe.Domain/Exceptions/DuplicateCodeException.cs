using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;

namespace Loyka.OnMuhasebe.Exceptions;
public class DuplicateCodeException : BusinessException
{
    public DuplicateCodeException(string kod) : base(OnMuhasebeDomainErrorCodes.DuplicateKod)
    {
        WithData("kod", kod);
    }
}
