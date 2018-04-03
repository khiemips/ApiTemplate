using Common.Entity;
using Common.Services;
using Entities.Materials;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Materials
{
    public interface IMaterialService : IService<Material> 
    {

        IEnumerable<Material> GetAll(string keyword);

    }
}
