using System;

namespace MathUtil
{
	public abstract class ValueModifier : IValueModifier
	{
		private double value;

		public double Value
		{
			get
			{
				return value;
			}
			set
			{
				if (this.value != value)
				{
					this.value = value;
					ValueChanged(this);
				}
			}
		}

		public event Action<IValueModifier> ValueChanged = delegate { };

		public ValueModifier(double value)
		{
			this.value = value;
		}

		public abstract double Modify(double value);
	}
}