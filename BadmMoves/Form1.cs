using BadmMoves.Commands;
using BadmMoves.Models;

namespace BadmMoves
{
    public partial class Form1 : Form
    {
        private Model _model = new Model();
        private readonly LinkedList<Command> _history = new LinkedList<Command>();
        private readonly LinkedList<Command> _redo = new LinkedList<Command>();

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

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxGame.SelectedIndex = 0;
            comboBoxServe.SelectedIndex = 0;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            var game = (Games)comboBoxGame.SelectedIndex;
            var serveIdx = comboBoxServe.SelectedIndex;

            var startCmd = new StartCmd() { Game = game, ServingPlayer = serveIdx };
            _model.ApplyCommand(startCmd);

            _history.Clear();
            _redo.Clear();
            _history.AddLast(startCmd);

            radioButtonStrike.Checked = true;

            Redraw();
        }

        private void panelMain_MouseClick(object sender, MouseEventArgs e)
        {
            var gc = GraphicContext.FromControl(panelMain);
            if (!gc.TryGetCourtPoint(e.X, e.Y, out var position))
                return;

            if (_model.TryLocatePlayer(position, out var index))
            {
                var selectCmd = new SelectCmd() { Player = index };
                _model.ApplyCommand(selectCmd);
                _history.AddLast(selectCmd);
                Redraw();
            }
        }

        private void panelMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var gc = GraphicContext.FromControl(panelMain);
            if (!gc.TryGetCourtPoint(e.X, e.Y, out var position))
                return;

            var index = _model.GetSelectedPlayer();

            Command command;
            if (radioButtonMove.Checked)
            {
                command = new MoveCmd { Position = position, Player = index };
            }
            else
            {
                command = new StrikeCmd { Position = position, Player = index };
            }

            _model.ApplyCommand(command);
            _history.AddLast(command);
            Redraw();
        }

        private void buttonUndo_Click(object sender, EventArgs e)
        {
            var cmd = _history.Last;
            if (cmd != null)
            {
                _history.RemoveLast();
                _redo.AddLast(cmd);

                foreach (var item in _history )
                {
                    _model.ApplyCommand( item );
                }
                Redraw();
            }
        }

        private void buttonRedo_Click(object sender, EventArgs e)
        {
            var cmd = _redo.Last;
            if (cmd != null)
            {
                _redo.RemoveLast();
                _history.AddLast(cmd);
            }
            foreach (var item in _history)
            {
                _model.ApplyCommand(item);
            }
            Redraw();
        }
    }
}