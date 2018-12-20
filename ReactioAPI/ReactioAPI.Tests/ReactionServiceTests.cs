using FluentAssertions;
using Xunit;
using ReactioAPI.Infrastructure.Services;
using Moq;
using ReactioAPI.Core.Repositories;
using AutoMapper;
using ReactioAPI.Core.Domain;
using System.Collections.Generic;
using ReactioAPI.Infrastructure.DTO;
using System.Linq;

namespace ReactioAPI.Tests
{
    public class ReactionServiceTests
    {
        private IReactionService m_reactionService;

        private Mock<IReactionRepository> m_reactionRepositoryMock;

        private Mock<IMapper> m_mapperMock;

        private readonly List<Reaction> m_reactionList;

        private readonly List<Substrate> m_substrateList;

        private readonly List<Product> m_productList;

        private Reaction m_reaction;

        public ReactionServiceTests()
        {
            m_substrateList = TestsHelper.SetupSubstartes();
            m_productList = TestsHelper.SetupProducts();

            m_reaction = TestsHelper.GetReaction(m_substrateList, m_productList);
            m_reactionList = new List<Reaction>()
            {
                m_reaction
            };

            m_reactionRepositoryMock = new Mock<IReactionRepository>();
            m_mapperMock = new Mock<IMapper>();
            var expected = TestsHelper.SetupReactionDTO();

            m_mapperMock.Setup(x => x.Map<Reaction, ReactionDTO>(m_reaction))
                        .Returns(expected);

            m_reactionRepositoryMock.Setup(x => x.GetReactionsAsync())
                                    .ReturnsAsync(m_reactionList);


            m_reactionService = new ReactionService(m_reactionRepositoryMock.Object, m_mapperMock.Object);
        }


        [Fact]
        public void get_reactions_async_from_reaction_service_should_not_be_empty()
        {
            //Arrange

            //Act
            var reactions = m_reactionService.GetReactionsAsync();

            //Assert
            m_reactionRepositoryMock.Verify(x => x.GetReactionsAsync(), Times.Once);
            m_mapperMock.Verify(x => x.Map<Reaction, ReactionDTO>(m_reaction), Times.Once);
            reactions.Result.Should().NotBeNullOrEmpty();
            reactions.Result.FirstOrDefault().Name.Should().Match("Methane synthesis");
            reactions.Result.FirstOrDefault().Products.Should().NotBeNullOrEmpty();
            reactions.Result.FirstOrDefault().Substrates.Should().NotBeNullOrEmpty();
            reactions.Result.Count().Should().Equals(1);
            reactions.Result.Should().BeOfType<List<ReactionDTO>>();
        }
    }
}
