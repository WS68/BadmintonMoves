namespace BadmMoves.Commands;

class StartCmd : Command
{
    public Games Game { get; init; }
    public int ServingPlayer { get; init; }
}