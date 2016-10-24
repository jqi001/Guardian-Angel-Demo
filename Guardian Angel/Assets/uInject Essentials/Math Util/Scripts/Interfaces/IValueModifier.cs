using System;

namespace MathUtil
{
	public interface IValueModifier
	{
		double Value
		{
			get;
			set;
		}

		event Action<IValueModifier> ValueChanged;

		double Modify(double value);
	}
}