using MongoDB.Bson;
using mp_Domain.Entities.Base;
using System.Collections.Generic;

namespace mp_Domain.Contracts.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        IList<T> GetAll();
        T GetById(ObjectId id);
        void Create(T entity);
    }
}