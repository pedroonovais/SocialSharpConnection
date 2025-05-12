using library.Model;
using Microsoft.AspNetCore.Mvc;
using service.Services;

namespace api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _service;

        public UserController(UserService service)
        {
            _service = service;
        }

        /// <summary>
        /// Returns all registered users.
        /// </summary>
        /// <response code="200">Returns the list of users.</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult Get()
        {
            var users = _service.GetAll();
            return Ok(users);
        }

        /// <summary>
        /// Returns a user by ID.
        /// </summary>
        /// <param name="id">ID of the user.</param>
        /// <response code="200">Returns the user.</response>
        /// <response code="404">User not found.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetById(long id)
        {
            var user = _service.GetById(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="input">User data.</param>
        /// <response code="201">User successfully created.</response>
        /// <response code="400">Invalid data.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] User input)
        {
            if (input == null || string.IsNullOrWhiteSpace(input.GetName()) ||
                string.IsNullOrWhiteSpace(input.GetEmail()) || string.IsNullOrWhiteSpace(input.GetUsername()) ||
                input.GetAge() <= 0)
                return BadRequest("Invalid user data.");

            var created = _service.Create(input);
            return CreatedAtAction(nameof(GetById), new { id = created.GetId() }, created);
        }

        /// <summary>
        /// Updates an existing user.
        /// </summary>
        /// <param name="id">ID of the user.</param>
        /// <param name="input">Updated user data.</param>
        /// <response code="200">User updated.</response>
        /// <response code="400">Invalid data.</response>
        /// <response code="404">User not found.</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Put(long id, [FromBody] User input)
        {
            if (input == null || id <= 0 || input.GetId() != id)
                return BadRequest("Invalid user data.");

            var updated = _service.Update(id, input);
            if (!updated)
                return NotFound();

            return Ok(input);
        }

        /// <summary>
        /// Deletes a user by ID.
        /// </summary>
        /// <param name="id">ID of the user.</param>
        /// <response code="204">User deleted.</response>
        /// <response code="400">Invalid ID.</response>
        /// <response code="404">User not found.</response>
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
