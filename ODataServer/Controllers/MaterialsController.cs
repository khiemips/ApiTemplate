using Entities.Materials;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ODataServer.Controllers
{
    public class MaterialsController : ODataBaseController<Material>
    {

        #region Contractor

        public MaterialsController(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
        }

        #endregion


        public IActionResult GetName(string key)
        {
            var material = Service.GetById(key);

            if (material == null)   
            {
                return NotFound();
            }

            return Ok(material.Name);
        }

        //public ActionResult GetDynamicProperty(string key, string dynamicProperty)
        //{
        //    var material = Service.GetById(key);
        //    if (material == null || !material.Dynamics.Keys.Contains(dynamicProperty))
        //    {
        //        return NotFound();
        //    }

        //    return Ok(material.Dynamics[dynamicProperty].ToString());
        //}

    }
}
