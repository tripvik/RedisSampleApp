using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace RedisSampleApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValuesController : ControllerBase
    {
        private readonly IConnectionMultiplexer _redis;

        public ValuesController(IConnectionMultiplexer redis)
        {
            _redis = redis;
        }

        [HttpGet("{key}")]
        public ActionResult<string> Get(string key)
        {
            var db = _redis.GetDatabase();
            var value = db.StringGet(key);

            if (value.IsNullOrEmpty)
            {
                return NotFound($"Value for key '{key}' not found");
            }
            return Ok(value.ToString());
        }

        [HttpPost("{key}/{value}")]
        public ActionResult Set(string key, string value)
        {
            var db = _redis.GetDatabase();
            bool wasSet = db.StringSet(key, value);

            if (wasSet)
            {
                return Ok();
            }
            return BadRequest("Failed to set value.");
        }
    }
}