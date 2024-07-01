public class GameMove
{
    public GameOption Option { get; }

    public GameMove(GameOption option)
    {
        Option = option;
    }

    public bool WinsOver(GameMove otherMove)
    {
        switch (Option)
        {
            case GameOption.Rock:
                return otherMove.Option == GameOption.Scissors;
            case GameOption.Paper:
                return otherMove.Option == GameOption.Rock;
            case GameOption.Scissors:
                return otherMove.Option == GameOption.Paper;
            default:
                return false;
        }
    }
}