using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReactioAPI.Infrastructure.Services;
using NLog;

namespace ReactioAPI.Controllers
{
    [Route("[controller]")]
    public class ReactionsController : Controller
    {
        private readonly IReactionService m_reactionService;

        private static Logger m_logger = LogManager.GetCurrentClassLogger();

        public ReactionsController(IReactionService reactionService)
        {
            m_reactionService = reactionService;
        }

        // GET api/reactions
        [ResponseCache(Duration = 3600)]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            m_logger.Debug("Get reactions fired");
            var reactions = await m_reactionService.GetReactionsAsync();

            return Json(reactions);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
