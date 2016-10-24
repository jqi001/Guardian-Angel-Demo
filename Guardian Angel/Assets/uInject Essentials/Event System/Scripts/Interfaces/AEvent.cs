using System;

namespace Events
{
	public abstract class AEvent<T> : Event<T> where T : EventArgs
	{
		public virtual string Name
		{
			get;
			protected set;
		}

		public abstract bool TriggerEvent(out EventArgs args);
	}
}