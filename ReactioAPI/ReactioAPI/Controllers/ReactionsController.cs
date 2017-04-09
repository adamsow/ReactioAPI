﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ReactioAPI.Infrastructure.Services;
using Reactio.Infrastructure.DTO;

namespace ReactioAPI.Controllers
{
    [Route("api/[controller]")]
    public class ReactionsController : Controller
    {
        private readonly IReactionService m_reactionService;

        public ReactionsController(IReactionService reactionService)
        {
            m_reactionService = reactionService;
        }
        
        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<ReactionDTO>> Get()
        {
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
