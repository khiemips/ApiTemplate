using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Values;
using Microsoft.AspNetCore.Mvc;

namespace ApiTemplate.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : ApiBaseController<User>
    {
        public UsersController(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {

        }

    }
}
