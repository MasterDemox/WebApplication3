using Google.Protobuf.Collections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
        [ApiController]
        [Route("comment")]
        public class CommentController : ControllerBase
        {
            [HttpGet]
            [Route("all")]

            public IActionResult GetAll()
            {
                var db = new MydbContext();
                return Ok(db.Comments);
            }

            [HttpGet]
            [Route("{id}")]

            public IActionResult Get(int id)
            {
                var db = new MydbContext();
                var comment = db.Comments.FirstOrDefault(x => x.Id == id);
                if (comment == null) { return NotFound(); }
                return Ok(comment);
        }
        [HttpPost]
            public IActionResult Add(Comment comment)
            {
                var db = new MydbContext();
                db.Comments.Add(comment);
                db.SaveChanges();
                return Ok();
            }
            [HttpPut]
            public IActionResult Update(Comment comment)
            {
                var db = new MydbContext();
                db.Comments.Update(comment);
                db.SaveChanges();
                return Ok(comment);
            }
            [HttpDelete]
            public IActionResult Delete(int id)
            {
                var db = new MydbContext();
                var comment = db.Comments.FirstOrDefault(x => x.Id == id);
                if (comment == null) { return NotFound(); }
                db.Comments.Remove(comment);
                db.SaveChanges();
                return Ok();
            }
        }
}
