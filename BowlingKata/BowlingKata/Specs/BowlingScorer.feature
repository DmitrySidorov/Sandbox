Feature: Bowling Score
	In order to know if I won
	As a bowler
	I want the system to calculate my total score

Scenario: All gutter game
	Given a new bowling game
	When I hit 0 and 0 pins in 10 frames
	Then the score should be 0

Scenario: One single pin
	Given a new bowling game
	When I hit 1 and 0 pins in 1 frame
	Then the score should be 1

Scenario: Two pins
	Given a new bowling game
	When I hit 1 and 1 pins in 1 frame
	Then the score should be 2

Scenario: Spare in second roll
	Given a new bowling game
	When I hit 0 and 10 pins in 1 frame
	And I hit 1 and 1 pins in next frame
	Then the score should be 13

Scenario: All 9
	Given a new bowling game
	When I hit 9 and 0 pins in 10 frames
	Then the score should be 90

Scenario: All spare
	Given a new bowling game
	When I hit 5 and 5 pins in 10 frames
	And I hit 5 in the extra roll
	Then the score should be 150

Scenario: Perfect game
	Given a new bowling game
	When I hit 10 pins in 10 frames
	And I hit 10 in the extra roll
	And I hit 10 in the extra roll
	Then the score should be 300
