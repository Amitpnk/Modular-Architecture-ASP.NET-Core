using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HA.Port.Card.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustValueController : ControllerBase
    {
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

    }
}

