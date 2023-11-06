using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadmMoves.Models
{
	internal abstract class ModelItem
	{
		public ModelItem Clone() => (ModelItem) this.MemberwiseClone();
		public abstract void Paint(PaintContext paintContext);
	}
}
