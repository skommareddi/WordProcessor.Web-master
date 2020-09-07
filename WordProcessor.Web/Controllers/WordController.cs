using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WordProcessor.Models;
using WordProcessor.Service.Contracts;

namespace WordProcessor.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WordController : ControllerBase
    {

        private readonly ILogger<WordController> _logger;
        private readonly IWordCountService wordCountService;

        public WordController(ILogger<WordController> logger, IWordCountService wordCountService)
        {
            _logger = logger;
            try
            {
                this.wordCountService = wordCountService;
               _logger.LogInformation("Initializing WordProcessor Controller");
            }
            catch(Exception e)
            {
                _logger.LogInformation(e.ToString());
                    throw e;
            }
        }


        [HttpPost]
        public IActionResult Post(WordCountInput input)
        {
            try
            {
                _logger.LogInformation("Processing {0}", input.Text);
                return Ok(wordCountService.Process(input));
            }
            catch (Exception e)
            {
                _logger.LogInformation(e.ToString());
                return BadRequest();
            }
        }
    }
}
