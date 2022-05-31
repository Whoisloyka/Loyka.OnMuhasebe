using System;
using Volo.Abp.Application.Services;

namespace Loyka.OnMuhasebe.Services;
public interface ICrudAppService<TGetOutPutDto, TGetListOutputDto, in TGetListInput, // başına in koyulanlar için: Tanımlama yapılırken in koyulur.
    in TCreateInput, in TUpdateInput> : 
    IReadOnlyAppService<TGetListOutputDto, TGetListOutputDto,Guid,TGetListInput>, // GetAsync ve GetListAsync getirir.
    ICreateAppService<TGetOutPutDto,TCreateInput>, // createInput ile verile alır kaydeder ve geri getirir.
    IUpdateAppService<TGetOutPutDto,Guid,TUpdateInput> // Guid ve UpdateInputları alır günceller ve geri getirir.
{

}
 public interface ICrudAppService<TGetOutPutDto, TGetListOutputDto, in TGetListInput,
    in TCreateInput, in TUpdateInput, in TGetCodeInput> :
    ICrudAppService<TGetOutPutDto, TGetListOutputDto, TGetListInput, TCreateInput, TUpdateInput>,
    IDeleteAppService<Guid>,
    ICodeAppService<TGetCodeInput>
{

}