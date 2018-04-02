using Common.Entity;
using Repository.Materials;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Materials
{
    public class MaterialService<T> : ServiceBase<T>, IMaterialService<T>
        where T: EntityBase
    {

        public MaterialService(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }

    }
}
