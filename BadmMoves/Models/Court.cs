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
		paintContext.Line( Line, Color.Black, new PointF( Line/2, Line/2 ), new PointF(Len - Line / 2, Line / 2));
		paintContext.Line(Line, Color.Black, new PointF(Len-Line / 2, Line / 2), new PointF(Len - Line / 2, Width - Line / 2));
		paintContext.Line(Line, Color.Black, new PointF(Len - Line / 2, Width - Line / 2), new PointF(Line / 2, Width - Line / 2) );
		paintContext.Line(Line, Color.Black, new PointF(Line / 2, Line / 2), new PointF(Line / 2, Width-Line / 2));
	}
}