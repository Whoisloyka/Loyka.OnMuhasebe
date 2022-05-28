using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Loyka.OnMuhasebe.Services;
public interface ICodeAppService<in TGetCodeInput> : IApplicationService
{
    Task<string> GetCodeAsync(TGetCodeInput input);
}
