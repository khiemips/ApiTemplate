using Common.Entity;
using Common.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Materials
{
    public interface IMaterialService<T> : IService<T> 
        where T : EntityBase 
    {
    }
}
