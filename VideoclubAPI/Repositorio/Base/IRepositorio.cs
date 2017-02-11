using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace VideoclubAPI.Repositorio.Base
{
    public interface IRepositorio<TView,TEntity> : IDisposable
    {
        TView Get(int pk);
        List<TView> Get();
        TView Add(TView model);
        TView Update(TView model);
        int Delete(int pk);
        int Delete(Expression<Func<TEntity, bool>> busqueda);
        List<TView> Find(Expression<Func<TEntity, bool>> busqueda);
        TEntity GetModelByPk(TView model);
    }
}
