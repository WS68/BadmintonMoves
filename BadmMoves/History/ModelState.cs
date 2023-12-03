using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BadmMoves.Commands;
using BadmMoves.Models;

namespace BadmMoves.History
{
	internal class ModelState
	{
		private readonly List<ModelItem> _players = new List<ModelItem>();
		private readonly List<ModelItem> _zones = new List<ModelItem>();
		private readonly List<ModelItem> _lines = new List<ModelItem>();

		private readonly List<Command> _commands = new List<Command>();

		public ModelState()
		{

		}

		public ModelState(IEnumerable<ModelItem> palyers, IEnumerable<ModelItem> zones, IEnumerable<ModelItem> lines)
		{
			_players.AddRange( palyers );
			_zones.AddRange( zones );
			_lines.AddRange( lines );
		}

		public IReadOnlyList<ModelItem> Players => _players;

		public IReadOnlyList<ModelItem> Zones => _zones;

		public IReadOnlyList<ModelItem> Lines => _lines;

		public IReadOnlyList<Command> Commands => _commands;

		public void SaveCommand(Command command)
		{
			_commands.Add( command );
		}

		public ModelState BuildState()
		{
			return new ModelState();
		}
	}
}
