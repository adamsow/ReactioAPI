using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReactioAPI.Infrastructure.Services;
using ReactioAPI.Infrastructure.DTO;
using NLog;

namespace ReactioAPI.Controllers
{
    [Route("api/[controller]")]
    public class ReactionsController : Controller
    {
        private readonly IReactionService m_reactionService;

        private static Logger m_logger = LogManager.GetCurrentClassLogger();

        public ReactionsController(IReactionService reactionService)
        {
            m_reactionService = reactionService;
        }
        
        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<ReactionDTO>> Get()
        {
            m_logger.Debug("Get reactions fired");
            return await m_reactionService.GetReactionsAsync();
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
