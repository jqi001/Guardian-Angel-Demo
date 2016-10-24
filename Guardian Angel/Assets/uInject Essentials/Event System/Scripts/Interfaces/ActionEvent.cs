using System;

namespace Events
{
	public class ActionEvent : AEvent<EventArgs>
	{
		private Func<bool> source;

		public ActionEvent(Func<bool> source)
		{
			this.source = source;
		}

		public override bool TriggerEvent(out EventArgs args)
		{
			if (source())
			{
				args = new EventArgs();
				return true;
			}
			else
			{
				args = null;
				return false;
			}
		}
	}
}