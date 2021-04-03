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
            var request = filterContext.HttpContext.Request;
            _dbContext.ApiRequestsLogs.Add(new ApiRequestsLogs()
            {
                EndpointName = request.Path.ToString(),
                ResourceName = request.Method.ToString(),
                RequestTime = DateTime.Now.ToString()
            });
            _dbContext.SaveChanges();
            base.OnActionExecuting(filterContext);
        }
    }
}
