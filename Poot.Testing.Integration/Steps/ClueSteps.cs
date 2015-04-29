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
        private RepositoryFactory _repositoryFactory;
        private GameService _gameService;
        private ClueService _clueService;
        private string _name;

        [BeforeScenario]
        public void Setup()
        {
            _repositoryFactory = new RepositoryFactory();
            _gameService = new GameService(_repositoryFactory);
            _clueService = new ClueService(_repositoryFactory);
            _gameService.DeleteAll();
        }

        [Given(@"I have one active game called '(.*)'")]
        public void GivenIHaveOneActiveGame(string name)
        {
            _name = name;
        }

        [Given(@"it has the following glyph clues:")]
        public void GivenItHasTheFollowingGlyphClues(Table table)
        {
            var clues = new List<Clue>();
            table.Rows.ToList().ForEach(row => clues.Add(new Clue(Int32.Parse(row["Clue"]), row["Glyph"])));

            _activeGame = new Game(_name, clues);
            _gameService.CreateNewGame(_activeGame);
        }

        [Given(@"I am playing my active game")]
        public void GivenIAmPlayingMyActiveGame()
        {
            
        }

        [When(@"I request the first clue")]
        public void WhenIRequestTheFirstClue()
        {
            var clueController = new ClueController(_clueService);
            var result = clueController.GetFirstClue("first");
            var contentResult = result as OkNegotiatedContentResult<Clue>;
            ScenarioContext.Current.Add("ClueResult", contentResult);
        }

        [When(@"I request the second clue")]
        public void WhenIRequestTheSecondClue()
        {
            var clueController = new ClueController(_clueService);
            var result = clueController.GetSecondClue("first");
            var contentResult = result as OkNegotiatedContentResult<Clue>;
            ScenarioContext.Current.Add("ClueResult", contentResult);
        }

        [Then(@"I should get Glyph '(.*)'")]
        public void ThenIShouldGetGlyph(string glyph)
        {
            var contentResult = (OkNegotiatedContentResult<Clue>)ScenarioContext.Current["ClueResult"];
            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.That(contentResult.Content.Glyph, Is.EqualTo(glyph));
        }
    }
}