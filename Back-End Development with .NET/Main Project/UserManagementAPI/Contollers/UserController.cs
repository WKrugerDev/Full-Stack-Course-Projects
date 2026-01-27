using Microsoft.AspNetCore.Mvc;
using UserManagementApi.Models; // Reference your User model and UserRole model
using System.Collections.Generic;
using System;
using UserManagementApi.DTOs;
using System.Diagnostics.CodeAnalysis;

namespace Controllers
{
    /// <summary>
    /// Controller for managing users.
    /// Provides CRUD operations for the User entity.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        // In-memory data store for now
        private static List<User> _users = new List<User>();
        private static int _nextId = 1; // For assigning unique IDs

        // GET: api/users
        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns>List of users (empty if none exist)</returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<IEnumerable<ReadUserDto>> GetAllUsers()
        {
            try
            {
                // Note: For large datasets, consider adding pagination or filtering
                // to avoid loading all users into memory at once.
                // Returning IEnumerable instead of List can reduce memory overhead
                // if the data is only enumerated once by the framework.

                var dtoList = _users.Select(u => new ReadUserDto
                {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email,
                Role = u.Role
                });

                return Ok(dtoList); // returns [] if empty
            }
            catch (Exception ex)
            {
                // This demonstrates handling potential errors (e.g., database issues in the future)
                // In production, consider logging this exception using ILogger
                return StatusCode(500, new { Message = "An error occurred while retrieving users.", Detail = ex.Message });
            }
        }

        // GET: api/users/{id}
        /// <summary>
        /// Get a specific user by ID
        /// </summary>
        /// <param name="id">ID of the user</param>
        /// <returns>User object if found</returns>
        /// <response code="200">Returns the user</response>
        /// <response code="404">User with specified ID not found</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ReadUserDto> GetUserById(int id)
        {
            var user = _users.Find(u => u.Id == id);
            if (user == null)
            {
                return NotFound(new { Message = $"User with ID {id} not found." });
            }

            var readDto = new ReadUserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Role = user.Role
            };

            return Ok(readDto); // For display purposes, keeps sensitive information separated while still getting user data
        }

        // POST: api/users
        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="dtoCreate">Data Transfer Object for creating a user</param>
        /// <returns>Created user object with assigned ID</returns>
        /// <response code="201">User created successfully</response>
        /// <response code="400">Invalid input or duplicate email</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<User> CreateUser([FromBody] CreateUserDto dtoCreate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // validates [Required] fields
            }

            if (string.IsNullOrWhiteSpace(dtoCreate.Name) || string.IsNullOrWhiteSpace(dtoCreate.Email))
            {
                return BadRequest(new { Message = "Name and Email are required." });
            }

            if (_users.Exists(u => u.Email.Equals(dtoCreate.Email, StringComparison.OrdinalIgnoreCase)))
            {
                return BadRequest(new { Message = "A user with this email already exists." });
            }

            

            
            var user = new User(
                _nextId++,
                dtoCreate.Name,
                dtoCreate.Email,
                dtoCreate.Role
            );

            _users.Add(user);

            //returns ReadUserData for output - displays only fields that are safe to display
            var readDto = new ReadUserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Role = user.Role
            };
            
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, readDto);
        }

        // PUT: api/users/{id}
        /// <summary>
        /// Update an existing user's details
        /// </summary>
        /// <param name="id">ID of the user to update</param>
        /// <param name="dtoUpdate">Data Transfer Object for updating a user</param>
        /// <returns>Updated user object</returns>
        /// <response code="200">User updated successfully</response>
        /// <response code="400">Invalid input or duplicate email</response>
        /// <response code="404">User with specified ID not found</response>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ReadUserDto> UpdateUser(int id, [FromBody] UpdateUserDto dtoUpdate)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingUser = _users.Find(u => u.Id == id);
            if (existingUser == null)
            {
                return NotFound(new { Message = $"User with ID {id} not found." });
            }

            if (string.IsNullOrWhiteSpace(dtoUpdate.Name) || string.IsNullOrWhiteSpace(dtoUpdate.Email))
            {
                return BadRequest(new { Message = "Name and Email are required." });
            }

            if (_users.Exists(u => u.Email.Equals(dtoUpdate.Email, StringComparison.OrdinalIgnoreCase) && u.Id != id))
            {
                return BadRequest(new { Message = "Another user with this email already exists." });
            }

            existingUser.Name = dtoUpdate.Name;
            existingUser.Email = dtoUpdate.Email;
            existingUser.Role = dtoUpdate.Role;

            //created and used in return for displaying non sensitive data
            var readDto = new ReadUserDto
            {
                 Id = existingUser.Id,
                Name = existingUser.Name,
                Email = existingUser.Email,
                Role = existingUser.Role
            };

            return Ok(readDto);
        }

        // DELETE: api/users/{id}
        /// <summary>
        /// Delete a user by ID
        /// </summary>
        /// <param name="id">ID of the user to delete</param>
        /// <response code="204">User deleted successfully</response>
        /// <response code="404">User with specified ID not found</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteUser(int id)
        {
            var user = _users.Find(u => u.Id == id);
            if (user == null)
            {
                return NotFound(new { Message = $"User with ID {id} not found." });
            }

            _users.Remove(user);
            return NoContent();
        }
    }
}
