using System;
using System.Collections.Generic;

namespace MyProject.Data
{
    public interface IRepository<TEntity, TID>
    {
        TEntity FindById(TID id);
        List<TEntity> FindAll();
        void DeleteById(TID id);
        void Delete(TEntity entity);
        TEntity Save(TEntity entity);
    }
}