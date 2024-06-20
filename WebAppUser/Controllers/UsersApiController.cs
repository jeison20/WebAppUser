using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using WebAppUser.Dtos;
using WebAppUser.Models;
using WebAppUser.Services;

namespace WebAppUser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersApiController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersApiController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Get all users.
        /// </summary> 
        /// <remarks>       
        /// <description>
        /// Returns Retrieve a list of all users.
        /// </description>
        /// </remarks>
        /// <response code="200">Returns Retrieve a list of all users.</response>
        /// <returns>Retrieve a list of all users.</returns>
        [HttpGet]        
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        // GET: Users/Details/5
        /// <summary>
        /// Get specific user.
        /// </summary>
        /// <remarks>       
        /// <description>
        ///   Returns Retrieve a user.
        /// </description>
        /// </remarks>
        /// <param name="id"></param>
        /// <response code="200">Retrieve a user.</response>
        /// <returns>Retrieve a user.</returns>
        [HttpGet("{id}")]        
        public async Task<ActionResult<User>> GetUserById(int id)
        {

            var user = await _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        // POST: Users/Create
        /// <summary>
        /// Create a new user.
        /// </summary>
        /// <remarks>       
        /// <description>
        ///   Create a new user with the provided details.
        /// </description>
        /// </remarks>
        /// <returns></returns>
        [HttpPost]       
        public async Task<ActionResult<User>> Create(CreateUserDto user)
        {
            User userModel = new()
            {
                Document = user.Document,
                Name = user.Name,
                Email = user.Email,
                Password = user.Password
            };            

            await _userService.AddUserAsync(userModel);
            return CreatedAtAction(nameof(Create), new { id = userModel.Id }, user);

        }


        /// <summary>
        /// Update a user.
        /// </summary>
        /// <remarks>       
        /// <description>
        ///   Update the details of an existing user.
        /// </description>
        /// </remarks>
        /// <param name="id">Id identifier of user</param>
        /// <param name="user">Object with information of the user</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update a user", Description = "Update the details of an existing user.")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Document,Name,Email,Password")] User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            await _userService.UpdateUserAsync(user);

            return NoContent();
        }

        // GET: Users/Delete/5
        /// <summary>
        /// Delete a user.
        /// </summary>
        /// <remarks>       
        /// <description>
        ///   Delete a user by their ID.
        /// </description>
        /// </remarks>
        /// <param name="id">Id identifier of user</param>
        /// <returns></returns>
        [HttpDelete("{id}")]        
        public async Task<IActionResult> Delete(int id)
        {
            var user = _userService.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            await _userService.DeleteUserAsync(id);
            return NoContent();
        }
    }
}

