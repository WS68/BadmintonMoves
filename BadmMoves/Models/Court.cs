namespace BadmMoves.Models;

class Court : ModelItem
{
	public const float Width = 1340;
	public const float Height = 610;
	public const float Line = 4;
	public const float ShortServeZone = 200;
	public const float LongServeZone = 76;

	public override void Paint(PaintContext paintContext)
	{
		//Outer bounds
		paintContext.Line( Line, Color.Black, new PointF( 0, Line/2 ), new PointF(Width, Line / 2));
		paintContext.Line(Line, Color.Black, new PointF(Width, Height - Line / 2), new PointF(0, Height - Line / 2));

		paintContext.Line(Line, Color.Black, new PointF(Width-Line / 2, Line / 2), new PointF(Width - Line / 2, Height - Line / 2));
		paintContext.Line(Line, Color.Black, new PointF(Line / 2, Line / 2), new PointF(Line / 2, Height-Line / 2));

		//serve lines
		paintContext.Line(Line, Color.Black, new PointF(Width /2 -  ShortServeZone, Line / 2), new PointF(Width / 2 - ShortServeZone, Height - Line / 2));
		paintContext.Line(Line, Color.Black, new PointF(Width / 2 + ShortServeZone, Line / 2), new PointF(Width / 2 + ShortServeZone, Height - Line / 2));

		paintContext.Line(Line, Color.Black, new PointF(Width - LongServeZone, Line / 2), new PointF(Width - LongServeZone, Height - Line / 2));
		paintContext.Line(Line, Color.Black, new PointF(LongServeZone, Line / 2), new PointF(LongServeZone, Height - Line / 2));

		//central lines
		paintContext.Line(Line, Color.Black, new PointF(0, Height / 2), new PointF(Width / 2 - ShortServeZone, Height / 2));
		paintContext.Line(Line, Color.Black, new PointF(Width, Height / 2), new PointF(Width / 2 + ShortServeZone, Height / 2));

		//vertical center
		paintContext.Line(true, Line, Color.Black, new PointF(Width / 2, Line / 2), new PointF(Width / 2, Height - Line / 2));

        paintContext.Text( "1", 20, Color.Black, new PointF(Width / 4 - 60, Height / 4 - 20 ) );
        paintContext.Text("2", 20, Color.Black, new PointF(3 * Width / 4 + 30, Height / 4 - 20 ));
        paintContext.Text("3", 20, Color.Black, new PointF(3 * Width / 4 + 30 , 3 * Height / 4));
        paintContext.Text("4", 20, Color.Black, new PointF(Width / 4 - 60, 3 * Height / 4 ));
	}
}