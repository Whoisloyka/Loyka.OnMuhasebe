using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loyka.OnMuhasebe.CommonDtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Loyka.OnMuhasebe.Bankalar;
public class BankaAppService : OnMuhasebeAppService, IBankaAppService
{
    // CRUD işlemleri için Repository pattern kullanıyoruz.
    // Bu yüzden bankayla ilgili CRUD işlemlerini yapacağımız servisin içinde IBankaRepositoryi Dependency Injection ile içeri alıyoruz.
    private readonly IBankaRepository _bankaRepository;

    public BankaAppService(IBankaRepository bankaRepository)
    {
        _bankaRepository = bankaRepository;// artık banka repositoryi kullanarak CRUD işlemlerimizi yapabiliriz.
    }

    public virtual async Task<SelectBankaDto> GetAsync(Guid id)
    {
        var entity = await _bankaRepository.GetAsync(id, b => b.Id == id); // b => b.Id == id bizim predicate filtremiz oluyor.
        return ObjectMapper.Map<Banka, SelectBankaDto>(entity);
    }
    public virtual async Task<PagedResultDto<ListBankaDto>> GetListAsync(BankaListParameterDto input)
    {
        var entities = await _bankaRepository.GetPagedLastListAsync(input.SkipCount,
            input.MaxResultCount,
            b => b.Durum == input.Durum, // predicate
            b => b.Kod); // orderBy

        var totalCount = await _bankaRepository.CountAsync(b=>b.Durum == input.Durum);

        return new PagedResultDto<ListBankaDto>(
            totalCount,
            ObjectMapper.Map<List<Banka>, List<ListBankaDto>>(entities)
            );
    }
    public virtual async Task<SelectBankaDto> CreateAsync(CreateBankaDto input)
    {
        // Kullanıcıdan aldığımız DTO'ları Domain katmanındaki Banka ile Map'liyoruz.
        var entity = ObjectMapper.Map<CreateBankaDto, Banka>(input); // input olarak gelen veriyi Dto olarak alıyoruz ve Banka entitysi ile mapliyoruz.
                                                                     // Sadece Domain katmanındaki entityleri DB'ye gönderebiliyoruz.
        await _bankaRepository.InsertAsync(entity); // maplediğimiz entity'i DB'de create ettik. Create aşamasında entitymize id alanı otomatik oluşturuldu.
        return ObjectMapper.Map<Banka, SelectBankaDto>(entity); //Oluşan entity'i tekrar mapleyip UI'a SelectBankaDto geri göndereceğiz.
    }
    public virtual async Task<SelectBankaDto> UpdateAsync(Guid id, UpdateBankaDto input)
    {
        var entity = await _bankaRepository.GetAsync(id, b => b.Id == id); // Update edeceğimiz entity id'si ile DB'den çekiyoruz.
        var mappedEntity = ObjectMapper.Map(input, entity); // Her iki dto da dolu geleceği için burda generic değil doğrudan mapleme yapıyoruz. 
                                                            // entity => DB'den gelen veriler, mappedEntity => UI'dan girildikten sonra değişikliğe uğrayan veriler.
                                                            // AutoMapperda eğer iki tane hazır instence alınmış veri varsa onları şekilde mapliyoruz. Eğer biri instence alınmış diğeri boş ise <> ile generic olarak mapliyoruz.
        return ObjectMapper.Map<Banka, SelectBankaDto>(mappedEntity);
    }
    public virtual async Task DeleteAsync(Guid id)
    {
        await _bankaRepository.DeleteAsync(id);
    }
    public virtual async Task<string> GetCodeAsync(CodeParameterDto input)
    {
        return await _bankaRepository.GetCodeAsync(b => b.Kod, b => b.Durum == input.Durum);
    }

    Task<ListBankaDto> IReadOnlyAppService<ListBankaDto, ListBankaDto, Guid, BankaListParameterDto>.GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}
