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
                    Position = new PointF( Court.Len / 2 - 250, Court.Width / 2 - 60 ),
					Number = 0,
					Selected = true,
                };
                ModelItems.Players.Append(player);

                player = new Player()
                {
                    Male = true, 
                    Position = new PointF(Court.Len / 2 - 400, Court.Width / 2 ),
                    Number = 1,
                };
                ModelItems.Players.Append(player);

                player = new Player() 
                { 
                    Male = true, 
                    Position = new PointF(Court.Len / 2 + 300, Court.Width / 2 + 100 ), 
                    Number = 2
                };
                ModelItems.Players.Append(player);

                player = new Player()
                {
                    Male = false, 
                    Position = new PointF(Court.Len / 2 + 400, Court.Width / 2 - 100 ),
                    Number = 3,
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
    }
}
