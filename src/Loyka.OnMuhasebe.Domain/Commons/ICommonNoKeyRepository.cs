using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Loyka.OnMuhasebe.Commons;

// DataBaseden id alanı olmayan verileri çekerken kullanacağız. Özellikle raporlarda kullanılacak.
public interface ICommonNoKeyRepository<TEntity> : IRepository<TEntity>
    where TEntity : class, IEntity // id alanı olmayan, class olan bir entity gelecek.
{
    Task<TEntity> FromSqlRawSingleAsync(string sql, params object[] parameters);
    Task<IList<TEntity>> FromSqlRawAsync(string sql, params object[] parameters);
}
