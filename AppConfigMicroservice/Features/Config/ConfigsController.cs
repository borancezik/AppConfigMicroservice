using AppConfigMicroservice.Features.Config.Data;
using Microsoft.AspNetCore.Mvc;

namespace AppConfigMicroservice.Features.Config
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigsController : ControllerBase
    {
        private readonly IConfigRepository _configRepository;

        public ConfigsController(IConfigRepository configRepository)
        {
            _configRepository = configRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _configRepository.GetAll();

            if (result == null)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
