using MongoDB.Bson;
using MongoDB.Driver;
using mp_Domain.Contracts.Repositories;
using mp_Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;

namespace mp_Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        Type nameObject = typeof(T);

        public IList<T> GetAll()
        {
            return PartnerContext.Instance.Database.GetCollection<T>($"{nameObject.Name}s").Find(p => p.Id != null).ToList();
        }

        public T GetById(ObjectId id)
        {
            return PartnerContext.Instance.Database.GetCollection<T>($"{nameObject.Name}s").Find(p => p.Id == id).FirstOrDefault();
        }

        public void Create(T entity)
        {
            PartnerContext.Instance.Database.GetCollection<T>($"{nameObject.Name}s").InsertOne(entity);
        }
    }
}