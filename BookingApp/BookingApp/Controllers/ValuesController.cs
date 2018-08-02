using BookingApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;

namespace BookingApp.Controllers
{
    
    public class ValuesController : ApiController
    {

        private BAContext db = new BAContext();
        public static List<BAIdentityUser> users = new List<BAIdentityUser>();
            public IQueryable<BAIdentityUser> GetAppUsers()
        {

            foreach (var entity in db.Users)
                users.Add(entity);
               
          
            return db.Users;
        }

      
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AppUserExists(int id)
        {
            return db.AppUsers.Count(e => e.Id == id) > 0;
        }
    }
}
