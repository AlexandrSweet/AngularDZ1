using BusinessLayer.Models;
using BusinessLayer.UserService;
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
        private readonly IPrivateDataService _userService;

        public PrivatDataController(IPrivateDataService userService)
        {
            _userService = userService;
        }
        [HttpGet]
        [Authorize]
        public IEnumerable<String> Get()
        {
            return new string[] { "First", "Second" };
        }

        [HttpGet]
        [Authorize]
        [Route ("get-private-users")]
        public List<User> GetAllUsers()
        {
            return _userService.GetPrivateData();
        }
    }
}
