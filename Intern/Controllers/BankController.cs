using intern.DataAccess.Data;
using Intern.Logic.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Text;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Intern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly ILogger<BankController> _logger;
        private readonly BankDatabaseContext _context;

        public BankController(ILogger<BankController> logger, BankDatabaseContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost("uploadedFile")]
        public IActionResult Post(IFormFile file)
        {
            try
            {
                if (file != null && file.Length > 0)
                {
                    using var stream = new StreamReader(file.OpenReadStream());
                    string? line;

                    var sb = new StringBuilder();
                    while ((line = stream.ReadLine()) != null)
                    {
                        sb.AppendLine(line);
                    }
                    var fileASText = sb.ToString();

                    var dataToParse = MT799Helper.ParseToMT799(fileASText);

                    // DatabaseContext.SwiftData?.Add(dataToParse);
                    _context.SwiftFiles.Add(dataToParse);
                    _context.SaveChanges();

                    return Ok(new { Message = "File Uploaded successfully." });
                }

                return BadRequest(new { Message = "File is missing or empty." });
            }
            catch (ArgumentException ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(new { Message = ex.Message });
            }

        }
    }
}
