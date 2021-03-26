using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.UserService
{
     public interface IPrivateDataService
    {
        List<User> GetPrivateData();
    }
}
