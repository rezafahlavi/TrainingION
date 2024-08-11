using BusinessService;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using TPAPI.Models;
using TrainingDomainModel;

namespace TPAPI.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public HttpResponseMessage Get()
        {
            UserService service = new UserService();
            IEnumerable<User> user = service.Get().AsEnumerable();

            return Request.CreateResponse(HttpStatusCode.OK, new { user });
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public HttpResponseMessage Post([FromBody] User user)
        {
            UserService service = new UserService();
            service.InsertUser(user);
            service.Save();
            
            return Request.CreateResponse(HttpStatusCode.OK, new { user });
        }

        // PUT api/values/5
        public HttpResponseMessage Put([FromBody] User user)
        {
            UserService service = new UserService();
            user.UserDetail.UserID = user.UserID;
            service.UpdateUser(user);
            service.Save();

            return Request.CreateResponse(HttpStatusCode.OK, new { user });
        }

        // DELETE api/values/5
        public HttpResponseMessage Delete(int UserID)
        {
            UserService service = new UserService();
            User user = service.GetBy(x => x.UserID == UserID).FirstOrDefault();
            service.DeleteUser(user);
            service.Save();

            return Request.CreateResponse(HttpStatusCode.OK, "Sukses dihapus");
        
    }
    }
}
