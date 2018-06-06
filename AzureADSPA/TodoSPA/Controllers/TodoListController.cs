using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TodoSPA.Controllers
{

    [Authorize]
    public class TodoListController : ApiController
    {
        public async Task<IEnumerable<ToGo>> Get()
        {
            CustomHttpClient client = new CustomHttpClient(Request.Headers.Authorization.Parameter);
            return await client.GetAsync();
        }

    }
}
