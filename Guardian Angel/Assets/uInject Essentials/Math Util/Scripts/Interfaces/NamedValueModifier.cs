using System;

namespace MathUtil
{
	public class NamedValueModifier : IValueModifier
	{
		private IValueModifier modifier;

		public string Name
		{
			get;
			private set;
		}

		public double Value
		{
			get
			{
				return modifier.Value;
			}
			set
			{
				modifier.Value = value;
			}
		}

		public event Action<IValueModifier> ValueChanged = delegate { };

		public NamedValueModifier(string name, IValueModifier modifier)
		{
			Name = name;
			this.modifier = modifier;
			modifier.ValueChanged += OnValueChanged;
		}

		public double Modify(double value)
		{
			return modifier.Modify(value);
		}

		private void OnValueChanged(IValueModifier obj)
		{
			ValueChanged(this);
		}
	}
}