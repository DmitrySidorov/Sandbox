using System.Collections.Generic;

namespace BowlingKata
{
    public class Bowling
    {
        private const int NumberOfPins = 10;

        private readonly List<int> _rolls = new List<int>();

        public void Roll(int pins)
        {
            _rolls.Add(pins);

            if(LastRollIsStrike())
                _rolls.Add(0);
        }

        private bool LastRollIsStrike()
        {
            return IsOddNumber(_rolls.Count) && _rolls[_rolls.Count -1] == NumberOfPins;
        }

        private static bool IsOddNumber(int number)
        {
            return number % 2 == 1;
        }

        public int Score()
        {
            int score = 0;
            for (int frame = 1; frame <= 10; frame++)
            {
                score += CalculateScoreFor(frame);
            }

            return score;
        }

        private int CalculateScoreFor(int frame)
        {
            if(IsStrikeAt(frame))
                return StrikeScoreFor(frame);

            if (IsSpareAt(frame))
                return SpareScoreFor(frame);

            return IntialScoreFor(frame);
        }

        private int StrikeScoreFor(int frame)
        {
            int score = IntialScoreFor(frame) + IntialScoreFor(Next(frame));

            if (IsStrikeAt(Next(frame)))
                score += ScoreAt(FirstRollFor(Next(Next(frame))));

            return score;
        }

        private int SpareScoreFor(int frame)
        {
            return IntialScoreFor(frame) + ScoreAt(FirstRollFor(Next(frame)));
        }

        private int IntialScoreFor(int frame)
        {
            return ScoreAt(FirstRollFor(frame)) + ScoreAt(SecondRollFor(frame));
        }

        private bool IsStrikeAt(int frame)
        {
            return ScoreAt(FirstRollFor(frame)) == NumberOfPins;
        }

        private bool IsSpareAt(int frame)
        {
            return IntialScoreFor(frame) == NumberOfPins;
        }

        private int ScoreAt(int roll)
        {
            return _rolls.Count > roll ? _rolls[roll] : 0;
        }

        private static int FirstRollFor(int frame)
        {
            return (frame - 1) * 2;
        }

        private static int SecondRollFor(int frame)
        {
            return FirstRollFor(frame) + 1;
        }

        private static int Next(int frame)
        {
            return frame + 1;
        }
    }
}