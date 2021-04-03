using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    public class ApiRequestsLogsDto
    {
        public string ResourceName { get; set; }
        public string EndpointName { get; set; }
        public string RequestTime { get; set; }
    }
}
