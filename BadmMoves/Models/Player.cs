namespace BadmMoves.Models;

class Player : ModelItem
{
    public bool Male { get; init; }

    public PointF Position { get; set; }

    public override void Paint(PaintContext paintContext)
    {
        var size = Male ? 80 : 60;
        var width = Male ? 60 : 50;

        var color = Male ? Color.Blue : Color.HotPink;

        paintContext.Oval( color, size, width, new PointF(  Position.X - width / 2, Position.Y - size / 2  ) );
    }
}