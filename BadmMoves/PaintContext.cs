using System.Drawing.Drawing2D;
using BadmMoves.Models;

namespace BadmMoves;

internal sealed class PaintContext
{
	private readonly Panel _panel;
	private readonly PaintEventArgs _args;

	private PointF _pTopLeft, _pTopRight, _pBottomLeft, _pBottomRight;

	private float _smToDots;
	private float _x;
	private float _y;

	public PaintContext(Panel panel, PaintEventArgs args)
	{
		_panel = panel;
		_args = args;

		Setup();
	}

	private void Setup()
	{
		int x = _panel.Width;
		int y = _panel.Height;

		float vx = (x / _args.Graphics.DpiX) / Court.Len;
		float vy = (y / _args.Graphics.DpiY ) / Court.Width;


		if (vx < vy)
		{
			//Будем ужимать высоту, чтобы сохранить пропорции

			y = (int) (vx * Court.Width * _args.Graphics.DpiY);
		}
		else
		{
			//Будем ужимать ширину, чтобы сохранить пропорции
			x = (int)(vy * Court.Len * _args.Graphics.DpiX);
		}

		_smToDots = (float)Math.Sqrt((x / Court.Len) * (x / Court.Len) + (y / Court.Width) * (y / Court.Width));

		_pTopLeft = new PointF(0, 0);
		_pTopRight = new PointF(x, 0);
		_pBottomLeft = new PointF(0, y);
		_pBottomRight = new PointF(x, y);

		_x = x;
		_y = y;
	}

	public void Line( float width, Color color, PointF x, PointF y )
	{
		Line(false, width, color, x, y);
	}

	public void Line(bool dotted, float width, Color color, PointF x, PointF y)
	{
		var lineW = ToWidth(width);
		var p = new Pen(color, lineW);
		if (dotted)
			p.DashPattern = new float[] { lineW, lineW };

		_args.Graphics.DrawLine(p, ToPoint(x), ToPoint(y));
	}


	private PointF ToPoint(PointF p)
	{
		var x = p.X * (_x / Court.Len) + _pTopLeft.X;
		var y = p.Y * (_y / Court.Width) + _pTopLeft.Y;

		return new PointF(x, y);
	}

	private float ToWidth(float width)
	{
		return width * _smToDots;
	}

    public void Text(string text, int height, Color color, PointF position)
    {
        var font = new Font(FontFamily.GenericSansSerif, ToWidth( height ), FontStyle.Regular, GraphicsUnit.Point);
        _args.Graphics.DrawString(text, font, new SolidBrush( color ), ToPoint( position ) );
    }
}