using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Entity;
using Common.Services;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace ApiTemplate.Controllers
{
    [Route("api/[controller]")]
    public class ApiBaseController<T> : ControllerBase
        where T : EntityBase
    {
        #region Contractor

        protected IService<T> Service { get; set; }

        public ApiBaseController(IServiceProvider serviceProvider)
        {
            Service = ServiceFactory.Resovle<T>(serviceProvider);
        }

        public ApiBaseController(IService<T> service)
        {
            Service = service;
        }

        #endregion


        [HttpGet]
        public IActionResult Get()
        {
            var result = Service.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var result = Service.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody]T entry)
        {
            var result = Service.Add(entry);
            return Ok(result);

        }

        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody]T entry)
        {
            Service.Update(id, entry);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            Service.Delete(id);
            return Ok();
        }
    }
}
