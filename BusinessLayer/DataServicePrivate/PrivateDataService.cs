using BusinessLayer.Models;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer.UserService
{
    public class PrivateDataService : IPrivateDataService
    {
        private readonly IApplicationDbContext _dbContext;
        public PrivateDataService(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<User> GetPrivateData()
        {
            var users = _dbContext.UserPrivate.ToList();
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
