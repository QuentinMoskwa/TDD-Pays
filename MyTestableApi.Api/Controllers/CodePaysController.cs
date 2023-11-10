using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MyTestableApi.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CodePaysController : ControllerBase
    {
        private Dictionary<string, string> alpha2Codes = new Dictionary<string, string>
        {
            { "France", "FR" },
            { "United States", "US" },
            { "Canada", "CA" },
            { "United Kingdom", "GB" },
        };

        private Dictionary<string, string> alpha3Codes = new Dictionary<string, string>
        {
            { "France", "FRA" },
            { "United States", "USA" },
            { "Canada", "CAN" },
            { "United Kingdom", "GBR" },
        };

        [HttpGet("GetAlpha2/{pays}")]
        public IActionResult GetAlpha2(string pays)
        {
            if (alpha2Codes.ContainsKey(pays))
            {
                return Ok(alpha2Codes[pays]);
            }
            return NotFound("Le code alpha-2 demandé n'as pas pu être trouvé");
        }

        [HttpGet("GetAlpha3/{pays}")]
        public IActionResult GetAlpha3(string pays)
        {
            if (alpha3Codes.ContainsKey(pays))
            {
                return Ok(alpha3Codes[pays]);
            }
            return NotFound("Le code alpha-3 demandé n'as pas pu être trouvé");
        }
    }
}
