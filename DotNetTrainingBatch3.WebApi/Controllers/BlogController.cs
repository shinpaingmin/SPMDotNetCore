using DotNetTrainingBatch3.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetTrainingBatch3.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly AppDbContext _db;

        public BlogController()
        {
            _db = new AppDbContext();
        }

        [HttpGet]
        public IActionResult GetBlog()
        {
            List<BlogModel> lst = _db.Blogs.OrderByDescending(x => x.BlogId).ToList();
            return Ok(lst);
        }

        [HttpGet(template:"{id}")]
        public IActionResult GetBlog(int id)
        {
            BlogModel? item = _db.Blogs.FirstOrDefault(item => item.BlogId == id);

            if(item is null)
            {
                return NotFound("Blog not found!");
            }

            return Ok(item);
        }

        [HttpPost]
        public IActionResult CreateBlog(BlogModel blog)
        {
            // add blog to blog model
            _db.Blogs.Add(blog);

            // db query here!
            int result = _db.SaveChanges();

            string message = result > 0 ? "Saved successfully!" : "Failed to save.";

            return Ok(message);
        }

        [HttpPut(template:"{id}")]
        public IActionResult UpdateBlog(int id, BlogModel blog)
        {
            BlogModel? item = _db.Blogs.FirstOrDefault(item => item.BlogId == id);  // put ? at the end of model cuz the blog could be not found
            
            if(item is null)
            {
                return NotFound("No blog found");
            }

            // update data using the existing model
            item.BlogTitle = blog.BlogTitle;
            item.BlogAuthor = blog.BlogAuthor;
            item.BlogContent = blog.BlogContent;

            int result = _db.SaveChanges();

            string message = result > 0 ? "Updated successfully!" : "Failed to update";

            return Ok(message);
        }

        [HttpDelete(template:"{id}")]
        public IActionResult DeleteBlog(int id)
        {
            BlogModel? item = _db.Blogs.FirstOrDefault(item => item.BlogId == id);

            if(item is null)
            {
                return NotFound("No blog found to delete");
            }

            _db.Blogs.Remove(item);
            int result = _db.SaveChanges();
            string message = result > 0 ? "Deleted Successfully!" : "Failed to delete.";
            
            return Ok(message);
        }

       
    }
}
