using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BadmMoves.Commands;
using BadmMoves.History;

namespace BadmMoves.Models
{
	internal class Model
	{
		private LinkedListNode<ModelItem> _pZones;
		private LinkedListNode<ModelItem> _pPlayers;
		private LinkedListNode<ModelItem> _pLines;

		private ModelState State = new ModelState();
		public Model()
		{
			ModelItems.AddFirst(new Court());
			_pZones = ModelItems.AddLast(new None());
			_pPlayers = ModelItems.AddLast(new None());
			_pLines = ModelItems.AddLast(new None());
		}
		public IEnumerable<ModelItem> Items => ModelItems;
		private LinkedList<ModelItem> ModelItems { get; } = new LinkedList<ModelItem>();

		public void ApplyCommand(Command command)
		{
            if (command is StartCmd sc)
            {
                RemovePlayers();

                var player = new Player() {Male = false, Position = new PointF( Court.Len / 2 - 250, Court.Width / 2 - 60 ) };
                var pos = ModelItems.AddAfter(_pPlayers, player);

                player = new Player() { Male = true, Position = new PointF(Court.Len / 2 - 400, Court.Width / 2 ) };
                pos = ModelItems.AddAfter(pos, player);

                player = new Player() { Male = true, Position = new PointF(Court.Len / 2 + 300, Court.Width / 2 + 100 ) };
                pos = ModelItems.AddAfter(pos, player);

                player = new Player() { Male = false, Position = new PointF(Court.Len / 2 + 400, Court.Width / 2 - 100 ) };
                pos = ModelItems.AddAfter( pos, player);

                return;
            }
		}

        private void RemovePlayers()
        {
            RemoveBetween(_pPlayers, _pLines);
        }

        private void RemoveBetween(LinkedListNode<ModelItem> from, LinkedListNode<ModelItem> end)
        {
            while (from.Next != end && from.Next != null )
            {
                ModelItems.Remove(from.Next);
            }
        }

        public static Model Build(IReadOnlyList<ModelItem> players, IReadOnlyList<ModelItem> zones, IReadOnlyList<ModelItem> lines)
		{
			var model = new Model();
			var link = model._pZones;
			foreach (var item in zones)
			{
				link = model.ModelItems.AddAfter(link, item);
			}
			link = model._pPlayers;
			foreach (var item in players)
			{
				link = model.ModelItems.AddAfter(link, item);
			}
			link = model._pLines;
			foreach (var item in lines)
			{
				link = model.ModelItems.AddAfter(link, item);
			}

			return model;
		}
	}
}
