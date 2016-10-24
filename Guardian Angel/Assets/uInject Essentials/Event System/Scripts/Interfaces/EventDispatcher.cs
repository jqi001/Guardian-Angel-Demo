using System;

namespace Events
{
	public interface EventDispatcher
	{
		void Subscribe<T>(Event<T> @event, EventHandler<T> action) where T : EventArgs;

		void Unsubscribe<T>(Event<T> @event, EventHandler<T> action) where T : EventArgs;
	}
}