using Microsoft.AspNetCore.Mvc;
using UserManagementApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace UserManagementApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private static List<User> _users = new List<User>
        {
            new User { Id = 1, Name = "Admin User", Email = "admin@example.com" }
        };

        // GET: api/users
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return Ok(_users);
        }

        // POST: api/users
        [HttpPost]
        public ActionResult<User> CreateUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            user.Id = _users.Count > 0 ? _users.Max(u => u.Id) + 1 : 1;
            _users.Add(user);
            return CreatedAtAction(nameof(GetUsers), new { id = user.Id }, user);
        }

        // PUT: api/users/1
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, [FromBody] User updatedUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            user.Name = updatedUser.Name;
            user.Email = updatedUser.Email;

            return NoContent();
        }

        // DELETE: api/users/1
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }

            _users.Remove(user);
            return NoContent();
        }
    }
}
