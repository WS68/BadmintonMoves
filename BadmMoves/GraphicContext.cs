using BadmMoves.Models;

namespace BadmMoves;

/// <summary>
/// Класс инкапсулирует в себя все вычисления координат на экране и на корте
/// </summary>
internal class GraphicContext
{
    private readonly Panel _panel;

    protected PointF _pTopLeft, _pTopRight, _pBottomLeft, _pBottomRight;

    private float _smToDots;
    private float _x;
    private float _y;

    public GraphicContext(Panel panel, Graphics graphics)
    {
        _panel = panel;
        Setup(graphics);
    }

    private void Setup(Graphics graphics)
    {
        int x = _panel.Width;
        int y = _panel.Height;

        float vx = (x / graphics.DpiX) / Court.Width;
        float vy = (y / graphics.DpiY) / Court.Height;


        if (vx < vy)
        {
            //Будем ужимать высоту, чтобы сохранить пропорции

            y = (int)(vx * Court.Height * graphics.DpiY);
        }
        else
        {
            //Будем ужимать ширину, чтобы сохранить пропорции
            x = (int)(vy * Court.Width * graphics.DpiX);
        }

        _smToDots = (float)Math.Sqrt((x / Court.Width) * (x / Court.Width) + (y / Court.Height) * (y / Court.Height));

        _pTopLeft = new PointF(0, 0);
        _pTopRight = new PointF(x, 0);
        _pBottomLeft = new PointF(0, y);
        _pBottomRight = new PointF(x, y);

        _x = x;
        _y = y;
    }


    public PointF ToScreenPoint(PointF p)
    {
        var x = p.X * (_x / Court.Width) + _pTopLeft.X;
        var y = p.Y * (_y / Court.Height) + _pTopLeft.Y;

        return new PointF(x, y);
    }

    public PointF ToScreenSize(PointF p)
    {
        var x = p.X * (_x / Court.Width);
        var y = p.Y * (_y / Court.Height);
        return new PointF(x, y);
    }

    public float ToScreenWidth(float width)
    {
        return width * _smToDots;
    }

    public static GraphicContext FromControl(Panel panel)
    {
        using var g = panel.CreateGraphics();
        return new GraphicContext(panel, g);
    }

    public bool TryGetCourtPoint(int x, int y, out PointF position )
    {
        if (x < _x && y < _y)
        {
            var xx = x * Court.Width / _x;
            var yy = y * Court.Height / _y;
            position = new PointF(xx, yy);
            return true;
        }

        position = default;
        return false;
    }
}