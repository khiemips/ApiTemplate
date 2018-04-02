using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Entity
{
    public class EntityBase
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator), Order = 1)]
        //[BsonId]
        [BsonIgnoreIfDefault]
        public string Id { get; set; }
    }
}
