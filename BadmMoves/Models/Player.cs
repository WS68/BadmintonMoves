using System.Diagnostics;

namespace BadmMoves.Models;

class Player : ModelItem
{
    private readonly int _number;
    public bool Male { get; init; }

    public PointF Position { get; set; }

    public int Number
    {
        get => _number;
        init
        {
            Debug.Assert( value is >= 0 and < 4 );
            _number = value;
        }
    }

    public bool Selected { get; set; }

    public bool LeftCourt => Number is 0 or 3;

    public bool RightCourt => Number is 1 or 2;

    public override void Paint(PaintContext paintContext)
    {
        var size = Height;
        var width = Width;

        var color = Male ? Color.Blue : Color.HotPink;
        var fillColor = Selected ?
            ( Male ? Color.LightBlue : Color.LightPink ) 
            : Color.White;

        paintContext.Oval( color, fillColor, size, width, new PointF(  Position.X - width / 2, Position.Y - size / 2  ));
    }

    public bool ContainesPoint(PointF point)
    {
        if (point.X < Position.X - Width / 2)
            return false;
        if (point.X > Position.X + Width / 2)
            return false;

        if (point.Y < Position.Y - Height / 2)
            return false;
        if (point.Y > Position.Y + Height / 2)
            return false;

        return true;
    }

    private int Width => Male ? 60 : 50;
    private int Height => Male ? 80 : 60;
}