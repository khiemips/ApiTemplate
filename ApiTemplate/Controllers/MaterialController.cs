using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Entity;
using Common.Services;
using Entities.Materials;
using Microsoft.AspNetCore.Mvc;
using Services.Materials;

namespace ApiTemplate.Controllers
{
    [Route("api/[controller]")]
    public class MaterialController : ApiBaseController<Material>
    {

        #region Contractor
        private IMaterialService _materialService { get; set; }

        public MaterialController(IServiceProvider serviceProvider, IMaterialService materialService)
            : base(serviceProvider)
        {
            _materialService = materialService;
        }


        [HttpGet("search")]
        public IActionResult Search(string keyword)
        {
            var result = _materialService.GetAll(keyword);

            return Ok(result);
        }

        
        #endregion


    }
}
