using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularDZ1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PrivatDataController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public IEnumerable<String> Get()
        {
            return new string[] { "First", "Second" };
        }
    }
}
