using System;

namespace Events.Impl
{
	public class FloatEvent : AEvent<FloatEventArgs>
	{
		private Func<float> source;

		public FloatEvent(Func<float> source)
		{
			this.source = source;
		}

		public override bool TriggerEvent(out EventArgs args)
		{
			args = new FloatEventArgs(source());
			return true;
		}
	}

	public class FloatEventArgs : EventArgs
	{
		public float Value
		{
			get;
			set;
		}

		public FloatEventArgs(float value)
		{
			this.Value = value;
		}
	}
}