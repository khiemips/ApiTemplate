using Common.Entity;
using Common.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Materials
{
    public class MaterialRepository<T> : RepositoryBase<T>, IMaterialRepository<T>
        where T : EntityBase
    {
        public MaterialRepository(MaterialRepository materialRepository)
            : base(materialRepository)
        {

        }
    }
}
