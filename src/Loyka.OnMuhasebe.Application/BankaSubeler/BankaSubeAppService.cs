using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Loyka.OnMuhasebe.BankaSubeler;
public class BankaSubeAppService : OnMuhasebeAppService, IBankaSubeAppService
{
    private readonly IBankaSubeRepository _bankaSubeRepository;
    public BankaSubeAppService(IBankaSubeRepository bankaSubeRepository)
    {
        _bankaSubeRepository = bankaSubeRepository;
    }



    public virtual async Task<SelectBankaSubeDto> GetAsync(Guid id)
    {
        var entity = await _bankaSubeRepository.GetAsync(id, 
            bs=>bs.Id == id, // predicate filtresi
            x=>x.Banka, x=>x.OzelKod1,x=>x.OzelKod2 // navigation property'leri ekliyoruz. (ICommonRepository'deki params(includeProperties)
            );

        return ObjectMapper.Map<BankaSube, SelectBankaSubeDto>(entity);
    }
    public virtual async Task<PagedResultDto<ListBankaSubeDto>> GetListAsync(BankaSubeListParameterDto input)
    {
        var entities = await _bankaSubeRepository.GetPagedLastListAsync(input.SkipCount, input.MaxResultCount,
            bs => bs.BankaId == input.BankaId && bs.Durum == input.Durum, //predicate (BankaSubeListParameterDto içindeki parametreler)
            bs => bs.Kod, // OrderBy
            bs => bs.Banka, bs => bs.OzelKod1, bs => bs.OzelKod2);  // params (includeProperties)

        var totalCount = await _bankaSubeRepository.CountAsync(bs => bs.BankaId == input.BankaId && bs.Durum == input.Durum);//UI'dan gelen data'nın bankaId'si ve Durum'u DB'dekiyle aynı olanların sayısıyını getirir.

        return new PagedResultDto<ListBankaSubeDto>(
            totalCount,
            ObjectMapper.Map<List<BankaSube>, List<ListBankaSubeDto>>(entities));
    }
    public virtual async Task<SelectBankaSubeDto> CreateAsync(CreateBankaSubeDto input)
    {
        var entity = ObjectMapper.Map<CreateBankaSubeDto, BankaSube>(input);

        await _bankaSubeRepository.InsertAsync(entity);// Maplediğimiz entityi DB'ye kaydediyoruz.

        return ObjectMapper.Map<BankaSube, SelectBankaSubeDto>(entity);
    }
    public virtual async Task<SelectBankaSubeDto> UpdateAsync(Guid id, UpdateBankaSubeDto input)
    {
        var entity = await _bankaSubeRepository.GetAsync(id, bs => bs.Id == id);
        var mappedEntity = ObjectMapper.Map(input, entity);

        await _bankaSubeRepository.UpdateAsync(mappedEntity);

        return ObjectMapper.Map<BankaSube, SelectBankaSubeDto>(mappedEntity);
    }
    public virtual async Task<string> GetCodeAsync(BankaSubeCodeParameterDto input)
    {
        return await _bankaSubeRepository.GetCodeAsync(x => x.Kod,
            x => x.BankaId == input.BankaId && x.Durum == input.Durum); 
    }
    public virtual async Task DeleteAsync(Guid id)
    {
        await _bankaSubeRepository.DeleteAsync(id);
    }








    Task<ListBankaSubeDto> IReadOnlyAppService<ListBankaSubeDto, ListBankaSubeDto, Guid, BankaSubeListParameterDto>.GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}
