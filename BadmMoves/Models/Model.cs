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
