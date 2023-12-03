namespace BadmMoves.Commands;

class MoveCmd : Command
{
    public int Player { get; init; }
    public PointF Position { get; init; }
}