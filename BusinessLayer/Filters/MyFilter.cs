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

            // не смог найти метод или свойство которое вернёт контроллер, костыль сделал
            string[] words = (request.Path.ToString()).Split(new char[] { '/' });

            _dbContext.ApiRequestsLogs.Add(new ApiRequestsLogs()
            {
                EndpointName = request.Path.ToString(),
                ResourceName = words[1],
                RequestTime = DateTime.Now.ToString()          

            });         


            _dbContext.SaveChanges();
            base.OnActionExecuting(filterContext);
        }
    }
}
