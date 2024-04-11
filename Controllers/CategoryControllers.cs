using Google.Protobuf.Collections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
        [ApiController]
        [Route("category")]
        public class CategoryControllers : ControllerBase
        {
            [HttpGet]
            [Route("all")]

            public IActionResult GetAll()
            {
                var db = new MydbContext();
                return Ok(db.Categories);
            }

            [HttpGet]
            [Route("{id}")]

            public IActionResult Get(int id)
            {
                var db = new MydbContext();
                var category = db.Categories.FirstOrDefault(x => x.Id == id);
                if (category == null) { return NotFound(); }
                return Ok(category);
        }
        [HttpPost]
            public IActionResult Add(Category category)
            {
                var db = new MydbContext();
                db.Categories.Add(category);
                db.SaveChanges();
                return Ok();
            }
            [HttpPut]
            public IActionResult Update(Category category)
            {
                var db = new MydbContext();
                db.Categories.Update(category);
                db.SaveChanges();
                return Ok(category);
            }
            [HttpDelete]
            public IActionResult Delete(int id)
            {
                var db = new MydbContext();
                var category = db.Categories.FirstOrDefault(x => x.Id == id);
                if (category == null) { return NotFound(); }
                db.Categories.Remove(category);
                db.SaveChanges();
                return Ok();
            }
        }
}
