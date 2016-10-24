using System;
using System.Collections.Generic;
using UnityEngine;

namespace Events.Impl
{
	public class EventDispatcherImpl : MonoBehaviour, EventDispatcher
	{
		private Dictionary<Event, EventHandlerList> subscribers;

		public void Subscribe<T>(Event<T> @event, EventHandler<T> action) where T : EventArgs
		{
			if (!subscribers.ContainsKey(@event))
			{
				subscribers[@event] = new EventHandlerList<T>();
			}
			subscribers[@event].Add(action);
		}

		public void Unsubscribe<T>(Event<T> @event, EventHandler<T> action) where T : EventArgs
		{
			if (subscribers.ContainsKey(@event))
			{
				subscribers[@event].Remove(action);
			}
		}

		private void Awake()
		{
			subscribers = new Dictionary<Event, EventHandlerList>();
		}

		private void Update()
		{
			foreach (Event e in subscribers.Keys)
			{
				EventArgs args;
				if (e.TriggerEvent(out args))
				{
					subscribers[e].TriggerEvent(this, args);
				}
			}
		}

		private abstract class EventHandlerList
		{
			public abstract void Add(object o);

			public abstract void Remove(object o);

			public abstract void TriggerEvent(object sender, EventArgs args);
		}

		private class EventHandlerList<T> : EventHandlerList where T : EventArgs
		{
			private List<EventHandler<T>> eventHandlers;

			public EventHandlerList()
			{
				eventHandlers = new List<EventHandler<T>>(16);
			}

			public override void Add(object o)
			{
				eventHandlers.Add((EventHandler<T>)o);
			}

			public override void Remove(object o)
			{
				eventHandlers.Remove((EventHandler<T>)o);
			}

			public override void TriggerEvent(object sender, EventArgs args)
			{
				T eventArgs = (T)args;
				foreach (EventHandler<T> handler in eventHandlers)
				{
					handler(sender, eventArgs);
				}
			}
		}
	}
}