using CreateYourOwnAdventure.Api.Controllers;
using CreateYourOwnAdventure.Core.Entities;
using CreateYourOwnAdventure.Core.Interfaces;
using CreateYourOwnAdventure.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assert = NUnit.Framework.Assert;

namespace CreateYourOwnAdventure.UnitTests.Controllers
{
    [TestClass]
    public class GameControllerTests
    {
        private Mock<ILogger<GameController>> _mockLogger;
        private Mock<IGameService> _mockGameService;
        private Game _validGameResponse;
        private List<Game> _validGamesResponse;
        private GameTraverse _validGameTraverseResponse;
        private List<GameTraverse> _validGamesTraverseResponse;
        private int _validAdventureId;
        private int _validGameId;
        private List<char> _validSteps;

        [TestInitialize]
        public void TestInitialize()
        {
            _mockLogger = new Mock<ILogger<GameController>>();
            _mockGameService = new Mock<IGameService>();
            _validAdventureId = 1;
            _validGameId = 1;
            _validSteps = new List<char>() { 'Y', 'N' };
        }

        [TestMethod]
        public async Task GetGames_ValidResponse()
        {
            //Arrange            
            _validGameResponse = BuildGameResponse();
            _validGamesResponse = new List<Game>() { _validGameResponse };
            _mockGameService.Setup(x => x.Get()).ReturnsAsync(_validGamesResponse);

            var systemUnderTest = new GameController(_mockLogger.Object, _mockGameService.Object);

            //Act
            var games = (ObjectResult) await systemUnderTest.Get();

            //Assert
            Assert.That(games.Value, Is.EqualTo(_validGamesResponse));
        }

        [TestMethod]
        public async Task GetGameById_ValidResponse()
        {
            //Arrange
            _validGameTraverseResponse = BuildGameTraverseResponse();
            _mockGameService.Setup(x => x.Get(_validGameId)).ReturnsAsync(_validGameTraverseResponse);

            var systemUnderTest = new GameController(_mockLogger.Object, _mockGameService.Object);

            //Act
            var adventure = (ObjectResult)await systemUnderTest.Get(_validGameId);

            //Assert
            Assert.That(adventure.Value, Is.EqualTo(_validGameTraverseResponse));
        }

        [TestMethod]
        public async Task CreateNewGame_ValidResponse()
        {
            //Arrange
            _mockGameService.Setup(x => x.Create(_validAdventureId, _validSteps)).ReturnsAsync(_validGameId);

            var systemUnderTest = new GameController(_mockLogger.Object, _mockGameService.Object);

            //Act
            var gameResult = (OkResult)await systemUnderTest.Create(_validAdventureId, _validSteps);

            //Assert
            Assert.That(gameResult.StatusCode, Is.EqualTo(StatusCodes.Status200OK));
        }

        private Game BuildGameResponse()
        {
            return new Game()
            {
                MyAdventureId = _validGameId,
                BinaryTreeId = 1,
                Steps = new List<char>() { 'Y','N','Y' }
            };            
        }

        private GameTraverse BuildGameTraverseResponse()
        {
            return new GameTraverse()
            {
                GameId = 1,
                Choices = new List<GameResponse>() 
                {
                    new GameResponse()
                    {
                        Question = "Do I Want A Donut?",
                        MyAdventure = 'Y'
                    },
                    new GameResponse()
                    {
                        Question = "Do You Deserve It?",
                        MyAdventure = 'N'
                    }
                }
            };
        }        
    }
}