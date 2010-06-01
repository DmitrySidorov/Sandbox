using System;
using TechTalk.SpecFlow;

namespace BowlingKata.Specs
{
    [Binding]
    public class StepDefinitions
    {
        private Bowling _bowling;

        [Given(@"a new bowling game")]
        public void GivenANewBowlingGame()
        {
            _bowling = new Bowling();
        }

        [When(@"I hit (\d+) and (\d+) pins in (\d+) frame(.*)")]
        public void WhenIHitPin(int pins1, int pins2, int frames, string ignore)
        {
            frames.Times(() =>
            {
                _bowling.Roll(pins1);
                _bowling.Roll(pins2);
            });
        }

        [When(@"I hit (\d+) and (\d+) pins in next frame")]
        public void WhenIHitPin(int pins1, int pins2)
        {
            _bowling.Roll(pins1);
            _bowling.Roll(pins2);
        }

        [When(@"I hit (\d+) pins in (\d+) frame(.*)")]
        public void WhenIHitPin(int pins, int frames, string ignore)
        {
            frames.Times(() => _bowling.Roll(pins));
        }

        [When(@"I hit (\d+) in the extra roll")]
        public void WhenIHitInTheExtraRoll(int pins)
        {
            _bowling.Roll(pins);
        }

        [Then(@"the score should be (\d+)")]
        public void ThenTheScoreShouldBe(int score)
        {
            _bowling.Score().ShouldEqual(score);
        }
    }

    public static class Helper
    {
        public static void Times(this int times, Action action)
        {
            for (int i = 0; i < times; i++)
            {
                action();
            }
        }
    }

}
