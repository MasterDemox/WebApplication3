using Google.Protobuf.Collections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
        [ApiController]
        [Route("post")]
        public class PostController : ControllerBase
        {
            [HttpGet]
            [Route("all")]

            public IActionResult GetAll()
            {
                var db = new MydbContext();
                return Ok(db.Posts);
            }

            [HttpGet]
            [Route("{id}")]

            public IActionResult Get(int id)
            {
                var db = new MydbContext();
                var post = db.Posts.FirstOrDefault(x => x.Id == id);
                if (post == null) { return NotFound(); }
                return Ok(post);
        }
        [HttpPost]
            public IActionResult Add(Post post)
            {
                var db = new MydbContext();
                db.Posts.Add(post);
                db.SaveChanges();
                return Ok();
            }
            [HttpPut]
            public IActionResult Update(Post post)
            {
                var db = new MydbContext();
                db.Posts.Update(post);
                db.SaveChanges();
                return Ok(post);
            }
            [HttpDelete]
            public IActionResult Delete(int id)
            {
                var db = new MydbContext();
                var post = db.Posts.FirstOrDefault(x => x.Id == id);
                if (post == null) { return NotFound(); }
                db.Posts.Remove(post);
                db.SaveChanges();
                return Ok();
            }
        }
}
