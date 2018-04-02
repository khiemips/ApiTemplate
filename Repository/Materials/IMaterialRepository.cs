using Common.Entity;
using Common.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Materials
{
    public interface IMaterialRepository<T> : IRepository<T>
        where T : EntityBase
    {
    }
}
