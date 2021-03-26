using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.DataServicePublic
{
    public interface IPublicDataService
    {
        List<User> GetPublicData();
    }
}
