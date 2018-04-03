using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Entity;
using Common.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNet.OData;
using Services;

namespace ODataServer.Controllers
{
   
    public class ODataBaseController<T> : ODataController
        where T : EntityBase
    {
        #region Contractor

        protected IService<T> Service { get; set; }

        public ODataBaseController(IServiceProvider serviceProvider)
        {
            Service = ServiceFactory.Resovle<T>(serviceProvider);
        }

        #endregion


        [EnableQuery]
        public IQueryable<T> Get()
        {
            var result = Service.GetAll();

            return result.AsQueryable();
        }

        public IActionResult Get(string key)
        {
            var material = Service.GetById(key);

            if (material == null)
            {
                return NotFound();
            }

            return Ok(material);
        }

        [HttpPost]
        public IActionResult Post([FromBody]T entry)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = Service.Add(entry);
            return Ok(result);
        }

        public IActionResult Put(string key, [FromBody]T entry)
        {
            Service.Update(key, entry);
            return Ok();
        }

        public IActionResult Delete(string key)
        {
            Service.Delete(key);
            return Ok();
        }

    }
}
