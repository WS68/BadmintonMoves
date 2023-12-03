using System.Drawing.Drawing2D;
using BadmMoves.Models;

namespace BadmMoves;

internal sealed class PaintContext: GraphicContext
{
	private readonly PaintEventArgs _args;

	public PaintContext(Panel panel, PaintEventArgs args)
	:base( panel, args.Graphics )
	{
		_args = args;
	}

	public void Line( float width, Color color, PointF x, PointF y )
	{
		Line(false, width, color, x, y);
	}

	public void Line(bool dotted, float width, Color color, PointF x, PointF y)
	{
		var lineW = ToScreenWidth(width);
		var p = new Pen(color, lineW);
		if (dotted)
			p.DashPattern = new float[] { lineW, lineW };

		_args.Graphics.DrawLine(p, ToScreenPoint(x), ToScreenPoint(y));
	}

	
    public void Text(string text, int height, Color color, PointF position)
    {
        var font = new Font(FontFamily.GenericSansSerif, ToScreenWidth( height ), FontStyle.Regular, GraphicsUnit.Point);
        _args.Graphics.DrawString(text, font, new SolidBrush( color ), ToScreenPoint( position ) );
    }

    public void Oval(Color color, Color fillColor, int height, int width, PointF position)
    {
        var size = ToScreenSize(new PointF(width, height));
        var pos = ToScreenPoint(position);

        var pen = new Pen(color, ToScreenWidth(4));
        Brush brash = new SolidBrush( fillColor );
        _args.Graphics.FillEllipse( brash, pos.X, pos.Y, size.X, size.Y);
        _args.Graphics.DrawEllipse(pen, pos.X, pos.Y, size.X, size.Y);
    }
}