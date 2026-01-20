using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ErrorHandlingAndLogging.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ErrorHandlingController : ControllerBase
    {
        private readonly ILogger<ErrorHandlingController> _logger;

        public ErrorHandlingController(ILogger<ErrorHandlingController> logger)
        {
            _logger = logger;
        }

        [HttpGet("division")]
        public IActionResult GetDivisionResult(int numerator, int denominator)
        {
            try
            {
                int result = numerator / denominator;
                return Ok(result);
            }
            catch (DivideByZeroException ex)
            {
                _logger.LogError(ex, "Division by zero attempted: {Numerator}/{Denominator}", numerator, denominator);
                return BadRequest("Cannot divide by zero.");
            }
        }
    }
}