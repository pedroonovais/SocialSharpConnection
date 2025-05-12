using library.Model;
using Microsoft.AspNetCore.Mvc;
using service.Services;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        private readonly PostService _service;

        public PostController(PostService service)
        {
            _service = service;
        }

        /// <summary>
        /// Returns all registered posts.
        /// </summary>
        /// <remarks>
        /// This endpoint returns a list of all posts available in the system.
        /// </remarks>
        /// <response code="200">Returns the list of posts.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            var posts = _service.GetAll();
            return Ok(posts);
        }

        /// <summary>
        /// Returns a specific post by ID.
        /// </summary>
        /// <param name="id">The ID of the post to retrieve.</param>
        /// <remarks>
        /// This endpoint returns a specific post based on the provided ID.
        /// </remarks>
        /// <response code="200">Returns the post data.</response>
        /// <response code="404">The post was not found.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(long id)
        {
            var post = _service.GetById(id);
            if (post == null)
                return NotFound();

            return Ok(post);
        }

        /// <summary>
        /// Creates a new post.
        /// </summary>
        /// <param name="post">The post object to be created.</param>
        /// <remarks>
        /// This endpoint creates a new post using the provided data.
        /// </remarks>
        /// <response code="201">The post was successfully created.</response>
        /// <response code="400">Invalid post data.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] Post post)
        {
            if (post == null || string.IsNullOrWhiteSpace(post.Author) ||
                string.IsNullOrWhiteSpace(post.Username) || string.IsNullOrWhiteSpace(post.Content))
            {
                return BadRequest("Invalid post data.");
            }

            var newPost = _service.Create(post);
            return CreatedAtAction(nameof(GetById), new { id = newPost.GetId() }, newPost);
        }

        /// <summary>
        /// Updates an existing post.
        /// </summary>
        /// <param name="id">The ID of the post to update.</param>
        /// <param name="post">The updated post data.</param>
        /// <remarks>
        /// This endpoint updates a post based on the provided ID and data.
        /// </remarks>
        /// <response code="200">The post was successfully updated.</response>
        /// <response code="400">Invalid post data.</response>
        /// <response code="404">The post was not found.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Put(long id, [FromBody] Post post)
        {
            if (post == null || id <= 0 || post.GetId() != id)
                return BadRequest("Invalid post data.");

            var updated = _service.Update(id, post);
            if (!updated)
                return NotFound();

            return Ok(post);
        }

        /// <summary>
        /// Deletes a post by ID.
        /// </summary>
        /// <param name="id">The ID of the post to delete.</param>
        /// <remarks>
        /// This endpoint deletes a post based on the provided ID.
        /// </remarks>
        /// <response code="204">The post was successfully deleted.</response>
        /// <response code="400">Invalid ID.</response>
        /// <response code="404">The post was not found.</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(long id)
        {
            if (id <= 0)
                return BadRequest("Invalid ID.");

            var deleted = _service.Delete(id);
            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}
