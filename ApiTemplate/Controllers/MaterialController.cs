using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Entity;
using Common.Services;
using Entities.Materials;
using Microsoft.AspNetCore.Mvc;

namespace ApiTemplate.Controllers
{
    [Route("api/[controller]")]
    public class MaterialController : ApiBaseController<Material>
    {
        #region Contractor

        public MaterialController(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }
        
        #endregion


    }
}
