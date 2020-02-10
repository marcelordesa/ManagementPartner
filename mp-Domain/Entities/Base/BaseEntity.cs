using MongoDB.Bson;

namespace mp_Domain.Entities.Base
{
    public abstract class BaseEntity
    {
        public ObjectId Id { get; private set; }
    }
}