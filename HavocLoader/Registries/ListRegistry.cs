using System.Collections.Generic;
using System.Linq;

namespace Havoc.Mod.Registries
{
	internal abstract class ListRegistry<T> : IRegistry<T>
	{
		protected List<T> Values { get; } = new List<T>();

		public virtual void Add(T item)
		{
			Values.Add(item);
		}

		public virtual IEnumerable<T> GetValues()
		{
			return Values.AsEnumerable();
		}
	}
}
