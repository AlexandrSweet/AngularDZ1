using DataAccessLayer;
using DataAccessLayer.Entities;
using System;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BusinessLayer.Filters
{
    public class MyFilter : ActionFilterAttribute
    {
        private readonly ApplicationDbContext _dbContext;
        public MyFilter (ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _dbContext.ApiRequestsLogs.Add(new ApiRequestsLogs()
            {
                EndpointName = filterContext.RouteData.Values["Action"].ToString(),
                ResourceName = filterContext.RouteData.Values["Controller"].ToString(),
                RequestTime = DateTime.Now.ToString()          

            });       

            _dbContext.SaveChanges();
            base.OnActionExecuting(filterContext);
        }
    }
}
