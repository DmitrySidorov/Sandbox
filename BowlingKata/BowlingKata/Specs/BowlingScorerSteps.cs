using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace BowlingKata.Specs
{
    [Binding]
    public class StepDefinitions
    {
        private Bowling bowling;

        [Given(@"a new bowling game")]
        public void GivenANewBowlingGame()
        {
            bowling = new Bowling();
        }

        [When(@"I hit (\d+) and (\d+) pins in (\d+) frame(.*)")]
        public void WhenIHitPin(int pins1, int pins2, int frames, string ignore)
        {
            frames.Times(() =>
            {
                bowling.Roll(pins1);
                bowling.Roll(pins2);
            });
        }

        [When(@"I hit (\d+) and (\d+) pins in next frame")]
        public void WhenIHitPin(int pins1, int pins2)
        {
            bowling.Roll(pins1);
            bowling.Roll(pins2);
        }

        [When(@"I hit (\d+) pins in (\d+) frame(.*)")]
        public void WhenIHitPin(int pins, int frames, string ignore)
        {
            frames.Times(() => bowling.Roll(pins));
        }

        [When(@"I hit (\d+) in the extra roll")]
        public void WhenIHitInTheExtraRoll(int pins)
        {
            bowling.Roll(pins);
        }

        [Then(@"the score should be (\d+)")]
        public void ThenTheScoreShouldBe(int score)
        {
            bowling.Score().ShouldEqual(score);
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
