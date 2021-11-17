using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JobSearchOrganizer.WebMVC.Controllers.WebAPI
{
    [Authorize]
    [RoutePrefix("api/job")]
    public class JobController : ApiController
    {
    }
}
