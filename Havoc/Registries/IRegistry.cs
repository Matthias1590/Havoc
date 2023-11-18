using System.Collections.Generic;

namespace Havoc.Mod.Registries
{
	public interface IRegistry<T>
	{
		void Add(T item);
		IEnumerable<T> GetValues();
	}
}
