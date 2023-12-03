using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadmMoves.Models
{
    internal sealed class ItemsCollection
    {
        private readonly ItemsLayer _zones;
        private readonly ItemsLayer _players;
        private readonly ItemsLayer _lines;

        private readonly List<ItemsLayer> _layers = new List<ItemsLayer>();
        private readonly LinkedList<ModelItem> _modelItems = new LinkedList<ModelItem>();

        public ItemsCollection()
        {
            _modelItems.AddFirst(new Court());

            _zones = CreateLayer();
            _lines = CreateLayer();
            _players = CreateLayer();
        }

        public ItemsLayer Zones => _zones;

        public ItemsLayer Players => _players;

        public ItemsLayer Lines => _lines;

        public IEnumerable<ModelItem> GetItems()
        {
            foreach (var item in _modelItems)
            {
                if ( item is None )
                    continue;
                yield return item;
            }    
        }

        public void Clear()
        {
            foreach (var layer in _layers)
            {
                layer.Clear();
            }
        }

        private ItemsLayer CreateLayer()
        {
            var start = _modelItems.AddLast(new None());
            var end = _modelItems.AddLast(new None());
            var layer = new ItemsLayer(_modelItems, start, end);
            _layers.Add( layer );
            return layer;
        }
    }
}
