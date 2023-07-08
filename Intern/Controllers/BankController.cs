using intern.DataAccess.Data;
using Intern.Logic.Helpers;
using Intern.Web.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Intern.Controllers
{
    public class BankController : ApiController
    {
        private readonly ILogger<BankController> _logger;
        private readonly BankDatabaseContext _context;

        public BankController(ILogger<BankController> logger, BankDatabaseContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPost(nameof(Upload))]
        public ActionResult Upload(IFormFile file)
        {

            if (!(file != null && file.Length > 0))
            {
                return BadRequest(new { Message = "File is missing or empty." });
            }

            using var stream = new StreamReader(file.OpenReadStream());
            string? line;

            var sb = new StringBuilder();

            while ((line = stream.ReadLine()) != null)
            {
                sb.AppendLine(line);
            }

            var fileASText = sb.ToString();

            var dataToParse = MT799Helper.ParseToMT799(fileASText);

            _context.SwiftFiles.Add(dataToParse);
            _context.SaveChanges();

            return Ok(new { Message = "File Uploaded successfully." });
        }
    }
}
