using BadmMoves.Models;

namespace BadmMoves
{
	public partial class Form1 : Form
	{
		private Model _model = new Model();

		public Form1()
		{
			InitializeComponent();
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
		}

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			timer.Enabled = true;
		}


		private void panelMain_Paint(object sender, PaintEventArgs e)
		{
			e.Graphics.Clear( panelMain.BackColor );

			var paintContext = new PaintContext(panelMain, e);
			foreach (var item in _model.Items)
			{
				item.Paint( paintContext );
			}
		}

		private void timer_Tick(object sender, EventArgs e)
		{
			timer.Enabled = false;
			panelMain.Invalidate();
		}
	}
}