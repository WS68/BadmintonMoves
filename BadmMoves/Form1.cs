using BadmMoves.Commands;
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
            e.Graphics.Clear(panelMain.BackColor);

            var paintContext = new PaintContext(panelMain, e);
            foreach (var item in _model.Items)
            {
                item.Paint(paintContext);
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            timer.Enabled = false;
            Redraw();
        }

        private void Redraw()
        {
            panelMain.Invalidate();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxGame.SelectedIndex = 0;
            comboBoxServe.SelectedIndex = 0;
        }

        private void comboBoxServe_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            var game = (Games) comboBoxGame.SelectedIndex;
            var serveIdx = comboBoxServe.SelectedIndex;

            _model.ApplyCommand( new StartCmd() { Game = game, ServingPlayer = serveIdx }  );
            Redraw();
        }
    }
}