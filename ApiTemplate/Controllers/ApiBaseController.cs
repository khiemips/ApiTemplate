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

        #endregion


        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var result = Service.GetAll();
            return Ok(result);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            var result = Service.GetById(id);
            return Ok(result);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]T entry)
        {
            var result = Service.Add(entry);
            return Ok(entry.Id);

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(string id, [FromBody]T entry)
        {
            Service.Update(id, entry);
            return Ok();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            Service.Delete(id);
            return Ok();
        }
    }
}
