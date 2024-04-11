using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
        [ApiController]
        [Route("user")]
        public class UserController : ControllerBase
        {
            [HttpGet]
            [Route("all")]

            public IActionResult GetAll()
            {
                var db = new MydbContext();
                return Ok(db.Users);
            }

            [HttpGet]
            [Route("{id}")]

            public IActionResult Get(int id)
            {
                var db = new MydbContext();
                var user = db.Users.FirstOrDefault(x => x.Id == id);
                if (user == null) { return NotFound(); }
                return Ok(user);
            }

            [HttpPost]
            public IActionResult Add(User user)
            {
                var db = new MydbContext();
                db.Users.Add(user);
                db.SaveChanges();
                return Ok();
            }
            [HttpPut]
            public IActionResult Update(User user)
            {
                var db = new MydbContext();
                db.Users.Update(user);
                db.SaveChanges();
                return Ok(user);
            }
            [HttpDelete]
            public IActionResult Delete(int id)
            {
                var db = new MydbContext();
                var user = db.Users.FirstOrDefault(x => x.Id == id);
                if (user == null) { return NotFound(); }
                db.Users.Remove(user);
                db.SaveChanges();
                return Ok();
            }
        }
}
