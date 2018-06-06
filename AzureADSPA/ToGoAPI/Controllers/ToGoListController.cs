using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Security.Claims;
using ToGoAPI.DAL;
using ToGoAPI.Models;
using System.Configuration;

namespace ToGoAPI.Controllers
{
    [Authorize]
    public class ToGoListController : ApiController
    {
        private static ToGoListServiceContext db = new ToGoListServiceContext();

        // GET: api/ToGoList
        public IEnumerable<ToGo> Get()
        {
            string owner = ClaimsPrincipal.Current.FindFirst("name").Value;
            IEnumerable<ToGo> currentUserToGos = db.ToGoes.Where(a => a.Owner == owner);
            return currentUserToGos;
        }

        // POST: api/ToGoList
        public void Post(ToGo ToGo)
        {
            string owner = ClaimsPrincipal.Current.FindFirst("name").Value;
            ToGo.Owner = owner;
            db.ToGoes.Add(ToGo);
        }
    }
}
