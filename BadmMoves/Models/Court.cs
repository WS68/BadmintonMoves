namespace BadmMoves.Models;

class Court : ModelItem
{
	public const float Len = 1340;
	public const float Width = 610;
	public const float Line = 4;
	public const float ShortServeZone = 200;
	public const float LongServeZone = 76;

	public override void Paint(PaintContext paintContext)
	{
		//Outer bounds
		paintContext.Line( Line, Color.Black, new PointF( 0, Line/2 ), new PointF(Len, Line / 2));
		paintContext.Line(Line, Color.Black, new PointF(Len, Width - Line / 2), new PointF(0, Width - Line / 2));

		paintContext.Line(Line, Color.Black, new PointF(Len-Line / 2, Line / 2), new PointF(Len - Line / 2, Width - Line / 2));
		paintContext.Line(Line, Color.Black, new PointF(Line / 2, Line / 2), new PointF(Line / 2, Width-Line / 2));

		//serve lines
		paintContext.Line(Line, Color.Black, new PointF(Len /2 -  ShortServeZone, Line / 2), new PointF(Len / 2 - ShortServeZone, Width - Line / 2));
		paintContext.Line(Line, Color.Black, new PointF(Len / 2 + ShortServeZone, Line / 2), new PointF(Len / 2 + ShortServeZone, Width - Line / 2));

		paintContext.Line(Line, Color.Black, new PointF(Len - LongServeZone, Line / 2), new PointF(Len - LongServeZone, Width - Line / 2));
		paintContext.Line(Line, Color.Black, new PointF(LongServeZone, Line / 2), new PointF(LongServeZone, Width - Line / 2));

		//central lines
		paintContext.Line(Line, Color.Black, new PointF(0, Width / 2), new PointF(Len / 2 - ShortServeZone, Width / 2));
		paintContext.Line(Line, Color.Black, new PointF(Len, Width / 2), new PointF(Len / 2 + ShortServeZone, Width / 2));

		//vertical center
		paintContext.Line(true, Line, Color.Black, new PointF(Len / 2, Line / 2), new PointF(Len / 2, Width - Line / 2));

	}
}