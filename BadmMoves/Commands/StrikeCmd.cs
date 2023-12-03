namespace BadmMoves.Commands;

class StrikeCmd : Command
{
    public int Player { get; init; }

    public PointF Position { get; init; }
}