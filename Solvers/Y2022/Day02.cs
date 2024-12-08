namespace AdventOfCode.Solvers.Y2022
{
    public class Day02 : BaseDay2022
    {
        protected override int Day => 2;

        private enum InputType
        {
            PlayerMove,
            GameResult,
        }

        private enum Move
        {
            Rock,
            Paper,
            Scissor
        }

        private enum Result
        {
            Lose,
            Tie,
            Win,
        }

        private readonly struct MoveData(Move aMove, char aOpponentMove, char aPlayerMove, Move aLose, Move aTie, Move aWin)
        {
            public readonly Move Move { get; } = aMove;
            public readonly char OpponentMove { get; } = aOpponentMove;
            public readonly char PlayerMove { get; } = aPlayerMove;
            public readonly Move Lose { get; } = aLose;
            public readonly Move Tie { get; } = aTie;
            public readonly Move Win { get; } = aWin;
        }

        private static readonly MoveData[] sMoveData = [
            new(Move.Rock, 'A', 'X', Move.Paper, Move.Rock, Move.Scissor),
            new(Move.Paper, 'B', 'Y', Move.Scissor, Move.Paper, Move.Rock),
            new(Move.Scissor, 'C', 'Z', Move.Rock, Move.Scissor, Move.Paper),
        ];

        private static readonly Tuple<char, Result>[] sResultData = [
            new('X', Result.Lose),
            new('Y', Result.Tie),
            new('Z', Result.Win),
        ];

        private static readonly Tuple<Move, int>[] sMoveScoreData = [
            new(Move.Rock, 1),
            new(Move.Paper, 2),
            new(Move.Scissor, 3),
        ];

        private static readonly Tuple<Result, int>[] sResultScoreData = [
            new(Result.Lose, 0),
            new(Result.Tie, 3),
            new(Result.Win, 6),
        ];

        public override ValueTask<string> SolvePart1(string[] aInput)
        {
            return new(PlayGames(aInput, InputType.PlayerMove).ToString());
        }

        public override ValueTask<string> SolvePart2(string[] aInput)
        {
            return new(PlayGames(aInput, InputType.GameResult).ToString());
        }

        private static int PlayGames(string[] aInput, InputType aInputType)
        {
            int finalScore = 0;
            foreach (string game in aInput)
            {
                string[] moves = game.Split();
                MoveData elfMove = sMoveData.Where(x => x.OpponentMove == moves[0][0]).First();
                MoveData playerMove;
                if (aInputType == InputType.GameResult)
                {
                    switch (sResultData.Where(x => x.Item1 == moves[1][0]).First().Item2)
                    {
                        case Result.Lose:
                            playerMove = sMoveData.Where(x => x.Move == elfMove.Win).First();
                            break;

                        case Result.Win:
                            playerMove = sMoveData.Where(x => x.Move == elfMove.Lose).First();
                            break;

                        default:
                        case Result.Tie:
                            playerMove = sMoveData.Where(x => x.Move == elfMove.Tie).First();
                            break;
                    }
                }
                else
                {
                    playerMove = sMoveData.Where(x => x.PlayerMove == moves[1][0]).First();
                }

                finalScore += sMoveScoreData.Where(x => x.Item1 == playerMove.Move).First().Item2;
                if (playerMove.Win == elfMove.Move)
                {
                    finalScore += sResultScoreData.Where(x => x.Item1 == Result.Win).First().Item2;
                }
                else if (playerMove.Tie == elfMove.Move)
                {
                    finalScore += sResultScoreData.Where(x => x.Item1 == Result.Tie).First().Item2;
                }
            }

            return finalScore;
        }
    }
}
