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

        float vx = (x / graphics.DpiX) / Court.Len;
        float vy = (y / graphics.DpiY) / Court.Width;


        if (vx < vy)
        {
            //Будем ужимать высоту, чтобы сохранить пропорции

            y = (int)(vx * Court.Width * graphics.DpiY);
        }
        else
        {
            //Будем ужимать ширину, чтобы сохранить пропорции
            x = (int)(vy * Court.Len * graphics.DpiX);
        }

        _smToDots = (float)Math.Sqrt((x / Court.Len) * (x / Court.Len) + (y / Court.Width) * (y / Court.Width));

        _pTopLeft = new PointF(0, 0);
        _pTopRight = new PointF(x, 0);
        _pBottomLeft = new PointF(0, y);
        _pBottomRight = new PointF(x, y);

        _x = x;
        _y = y;
    }


    public PointF ToScreenPoint(PointF p)
    {
        var x = p.X * (_x / Court.Len) + _pTopLeft.X;
        var y = p.Y * (_y / Court.Width) + _pTopLeft.Y;

        return new PointF(x, y);
    }

    public PointF ToScreenSize(PointF p)
    {
        var x = p.X * (_x / Court.Len);
        var y = p.Y * (_y / Court.Width);
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
            var xx = x * Court.Len / _x;
            var yy = y * Court.Width / _y;
            position = new PointF(xx, yy);
            return true;
        }

        position = default;
        return false;
    }
}