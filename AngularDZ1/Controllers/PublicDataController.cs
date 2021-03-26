using BusinessLayer.DataServicePublic;
using BusinessLayer.Models;
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
    public class PublicDataController : ControllerBase
    {
        private readonly IPublicDataService _userService;

        public PublicDataController(IPublicDataService userService)
        {
            _userService = userService;
        }
        
        [HttpGet]        
        [Route("get-publicUsers")]
        public List<User> GetAllPublicUsers()
        {
            return _userService.GetPublicData();
        }
    }
}
