using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using BadmMoves.Commands;
using BadmMoves.History;

namespace BadmMoves.Models
{
	internal class Model
    {
        private readonly ItemsCollection _items = new ItemsCollection();
        private ItemsCollection ModelItems => _items;
		public IEnumerable<ModelItem> Items => _items.GetItems();

		public void ApplyCommand(Command command)
		{
            if (command is StartCmd sc)
            {
                ModelItems.Clear();

                var player = new Player() {Male = false, 
                    Position = new PointF( Court.Width / 2 - 250, Court.Height / 2 - 60 ),
					Number = 0,
					Selected = true,
                };
                ModelItems.Players.Append(player);

                player = new Player()
                {
                    Male = true, 
                    Position = new PointF(Court.Width / 2 - 400, Court.Height / 2 ),
                    Number = 3,
                };
                ModelItems.Players.Append(player);

                player = new Player() 
                { 
                    Male = true, 
                    Position = new PointF(Court.Width / 2 + 300, Court.Height / 2 + 100 ), 
                    Number = 1
                };
                ModelItems.Players.Append(player);

                player = new Player()
                {
                    Male = false, 
                    Position = new PointF(Court.Width / 2 + 400, Court.Height / 2 - 100 ),
                    Number = 2,
                };
                ModelItems.Players.Append(player);

                return;
            }

            if (command is SelectCmd sel)
            {
                foreach (var item in ModelItems.Players.OfType<Player>())
                {
                    item.Selected = item.Number == sel.Player;
                }
                return;
            }

            if (command is MoveCmd mv)
            {
                _items.Zones.Clear();

                var player = GetPlayer(mv.Player);
                _items.Lines.RemoveWhere<Strike>( i => i.Player == player );
                player.Move ( mv.Position ); 
                return;
            }

            if (command is StrikeCmd st )
            {
                var player = GetPlayer(st.Player);
                var strike = new Strike(player, st.Position);
                _items.Lines.Append(strike);
                return;
            }
        }

        public bool TryLocatePlayer(PointF position, out int index )
        {
            foreach (var item in ModelItems.Players.OfType<Player>())
            {
                if (item.ContainesPoint(position))
                {
                    index = item.Number;
                    return true;
                }
            }

            index = -1;
            return false;
        }

        public int GetSelectedPlayer()
        {
            return _items.Players.OfType<Player>()
                .First(p => p.Selected).Number;
        }

        private Player GetPlayer(int index)
        {
            return _items.Players.OfType<Player>()
                .First(p => p.Number == index);
        }
    }
}
