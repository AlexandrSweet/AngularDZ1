using BusinessLayer.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer.DataServicePublic
{
    public class PublicDataService : IPublicDataService
    {
        public readonly IApplicationDbContext _dbContext;
        public PublicDataService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<User> GetPublicData()
        {
            var users = _dbContext.UserPublic.ToList();
            var userResalt = new List<User>();
            foreach (var user in users)
            {
                var mappedUser = new User { FirstName = user.FirstName, LastName = user.LastName };
                userResalt.Add(mappedUser);
            }
            return userResalt;           
        }
    }
}
