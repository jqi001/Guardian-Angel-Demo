using Events.Impl;
using Ninject;
using Ninject.Unity;
using System;
using UnityEngine;

namespace Events.Test
{
	public class EventTest : DIMono
	{
		public static readonly ActionEvent SomeActionEvent = new ActionEvent(() => { return UnityEngine.Input.GetMouseButton(0); });
		public static readonly FloatEvent SomeFloatEvent = new FloatEvent(() => { return UnityEngine.Input.GetAxis("Horizontal"); });

		[Inject]
		private EventDispatcher EventDispatcher
		{
			get;
			set;
		}

		private void Start()
		{
			EventDispatcher.Subscribe(SomeActionEvent, OnActionEvent);
			EventDispatcher.Subscribe(SomeFloatEvent, OnFloatEvent);
		}

		private void OnActionEvent(object sender, EventArgs args)
		{
			Debug.Log("action event");
		}

		private void OnFloatEvent(object sender, FloatEventArgs f)
		{
			Debug.Log(f.Value);
		}
	}
}