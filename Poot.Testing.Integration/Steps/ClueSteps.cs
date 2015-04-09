using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Poot.DataAccess.Implementations;
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
            ScenarioContext.Current.Pending();
        }

        [When(@"I request the (first|second) clue")]
        public void WhenIRequestTheFirstClue(string clueNumber)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I should get Glyph '(.*)'")]
        public void ThenIShouldGetGlyph(string glyph)
        {
            ScenarioContext.Current.Pending();
        }
    }
}