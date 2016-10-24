using System;

namespace Events
{
	public interface Event
	{
		string Name
		{
			get;
		}

		bool TriggerEvent(out EventArgs args);
	}

	public interface Event<T> : Event where T : EventArgs
	{
	}
}