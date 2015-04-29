Feature: Clues
	In order to guess a poot
	As a game player
	I want to see the clues

Background:
	Given I have one active game called 'first'
	And it has the following glyph clues:
	| Clue | Glyph |
	| 1    | a     |
	| 2    | b     |
	| 3    | c     |

Scenario: Get the first clue for a game
	Given I am playing my active game
	When I request the first clue
	Then I should get Glyph 'a'

Scenario: Get the second clue for a game
	Given I am playing my active game
	When I request the second clue
	Then I should get Glyph 'b'
#
#	Queue one up?
#	Auth
#	Logging
#	Partition
#	Scale