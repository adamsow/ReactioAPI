﻿using System.Collections.Generic;
using Xunit;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ReactioAPI.Infrastructure.DTO;
using System.Linq;
using FluentAssertions;

namespace ReactioAPI.Tests.EndToEnd.Controllers
{
    public class ReactionControllerTests
    {
        private readonly TestServer m_server;

        private readonly HttpClient m_client;

        public ReactionControllerTests()
        {
            m_server = new TestServer(new WebHostBuilder()
                        .UseStartup<Startup>());
            m_client = m_server.CreateClient();
        }

        [Fact]
        public async Task get_reactions_should_not_be_empty()
        {
            var response = await m_client.GetAsync("reactions");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var reactions = JsonConvert.DeserializeObject<IEnumerable<ReactionDTO>>(responseString);

            reactions.Should().NotBeNullOrEmpty();
            reactions.Should().BeOfType<List<ReactionDTO>>();

            var reaction = reactions.FirstOrDefault();
            reaction.Products.Should().NotBeNullOrEmpty();
            reaction.Substrates.Should().NotBeNullOrEmpty();
        }
    }
}
