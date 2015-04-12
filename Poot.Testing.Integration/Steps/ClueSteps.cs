using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http.Results;
using NUnit.Framework;
using Poot.Api.Controllers;
using Poot.DAL.Repositories;
using Poot.Models;
using Poot.Service;
using TechTalk.SpecFlow;

namespace Poot.Testing.Integration.Steps
{
    [Binding]
    public class ClueSteps
    {
        private Game _activeGame;
        private GameRepository _gameRepository;
        private GameService _gameService;
        
        [BeforeScenario]
        public void Setup()
        {
            _gameRepository = new GameRepository();
            _gameService = new GameService(_gameRepository);
        }

        [Given(@"I have one active game")]
        public void GivenIHaveOneActiveGame()
        {
        }

        [Given(@"it has the following glyph clues:")]
        public void GivenItHasTheFollowingGlyphClues(Table table)
        {
            var clues = new List<Clue>();
            table.Rows.ToList().ForEach(row => clues.Add(new Clue(Int32.Parse(row["Clue"]), row["Glyph"])));

            _activeGame = new Game(clues);
            _gameService.CreateNewGame(_activeGame);
        }

        [Given(@"I am playing my active game")]
        public void GivenIAmPlayingMyActiveGame()
        {
            
        }

        [When(@"I request the (first|second) clue")]
        public void WhenIRequestTheFirstClue(string clueNumber)
        {
            var gameController = new GameController(_gameService);
            var result = gameController.GetGame(1);
            var contentResult = result as OkNegotiatedContentResult<Game>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(42, contentResult.Content.Clues);

        }

        [Then(@"I should get Glyph '(.*)'")]
        public void ThenIShouldGetGlyph(string glyph)
        {
            ScenarioContext.Current.Pending();
        }
    }
}