using System.Collections.Generic;

namespace Data
{
    public interface IRepository<TEntity, TID>
    {
        TEntity FindById(TID id);
        List<TEntity> FindAll();
        TEntity Save(TEntity entity);
        void DeleteById(TID id);
        void Delete(TEntity entity);
        
    }
}