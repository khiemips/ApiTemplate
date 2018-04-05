using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Services;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace ApiTemplate.Controllers
{
    [Route("api/[controller]")]
    public class QuotationController : ApiBaseController<Quotation>
    {
        public QuotationController(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
    
    }
}
