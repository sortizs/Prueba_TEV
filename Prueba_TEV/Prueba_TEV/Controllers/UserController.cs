using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Prueba_TEV.Models;

namespace Prueba_TEV.Controllers
{
    public class UserController : ApiController
    {
        IUserRepository _repository;

        public UserController(IUserRepository repository)
        {
            _repository = repository;
        }

        // GET: api/User
        public IEnumerable<User> Get()
        {
            return _repository.GetUsers();
        }

        // GET: api/User/1
        public IHttpActionResult Get(int id)
        {
            var user = _repository.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST: api/User
        public IHttpActionResult Post(User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _repository.CreateUser(user);
            return CreatedAtRoute("DefaultApi", new { id = user.ID }, user);
        }

        // PUT: api/User/1
        public IHttpActionResult Put(int id, [FromBody]User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(_repository.UpdateUser(id, user));
        }

        // DELETE: api/User/1
        public IHttpActionResult Delete(int id)
        {
            _repository.DeleteUser(id);
            var user = _repository.GetUser(id);
            if (user != null)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
