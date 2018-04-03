using Common.Entity;
using Entities.Materials;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Materials
{
    public class MaterialService : ServiceBase<Material>, IMaterialService
    {


        public MaterialService(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }

        public IEnumerable<Material> GetAll(string keyword)
        {
            var resutl = Repository.GetAll(x => x.StandardFilteringFullText.Contains(keyword));

            return resutl;
        }
    }
}
