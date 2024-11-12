﻿using API.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        

        [HttpGet("unauthorized")]
        public IActionResult GetUnathuorized()
        {
            return Unauthorized();

        }

        [HttpGet("badrequest")]
        public IActionResult GetBadRequest()
        {
            return BadRequest("Not a good request");

        }

        [HttpGet("notfound")]
        public IActionResult GetNotFound()
        {
            return NotFound();

        }

        [HttpGet("internalerror")]
        public IActionResult GetInternalError()
        {
            throw new Exception("This is a test exception");

        }

        [HttpPost("validationerror")]
        public IActionResult GetValidationError(CreateProductDto product)
        {

            return Ok();
        }


        [Authorize]
        [HttpGet("secret")]
        public IActionResult GetSecret()
        {
            var name = User.FindFirst(ClaimTypes.Name)?.Value;
            var id = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return Ok("Hello " + name + " with the id of " + id); 

        }

    }
}