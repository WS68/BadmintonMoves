namespace BadmMoves.Models;

class Strike : ModelItem
{
    private readonly Player _player;
    private readonly PointF _to;

    public Strike(Player player, PointF to)
    {
        _player = player;
        _to = to;
    }

    public Player Player => _player;

    public override void Paint(PaintContext paintContext)
    {
        var color = Player.Male ? Color.Blue : Color.HotPink;
        paintContext.Line( false, 4, color, Player.Position, _to );
    }
}