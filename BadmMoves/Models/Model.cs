using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadmMoves.Models
{
	internal class Model
	{
		public Model()
		{
			ModelItems.AddFirst(new Court());
		}
		public IEnumerable<ModelItem> Items => ModelItems;
		private LinkedList<ModelItem> ModelItems { get; } = new LinkedList<ModelItem>();
	}
}
