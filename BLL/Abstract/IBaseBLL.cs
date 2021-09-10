using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface IBaseBLL<TEntity>
        where TEntity:IEntity
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void DeleteByID(int entityId);
        TEntity GetEntity(int entityId);
        ICollection<TEntity> GetAll();


    }
}
