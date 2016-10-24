using System;
using System.Collections.Generic;

namespace MathUtil
{
	public sealed class ModifiableValue<T> where T : IValueModifier
	{
		private double baseValue;
		private List<T> mods;

		public double BaseValue
		{
			get
			{
				return baseValue;
			}
			set
			{
				if (baseValue != value)
				{
					baseValue = value;
					CalcValue();
				}
			}
		}

		public float FBase
		{
			get
			{
				return (float)BaseValue;
			}
		}

		public double Value
		{
			get;
			private set;
		}

		public float FValue
		{
			get
			{
				return (float)Value;
			}
		}

		public double Ratio
		{
			get
			{
				return Value / baseValue;
			}
		}

		public float FRatio
		{
			get
			{
				return (float)Ratio;
			}
		}

		public event Action<ModifiableValue<T>> ValueChanged = delegate { };

		public ModifiableValue(double baseValue)
		{
			mods = new List<T>();
			BaseValue = baseValue;
		}

		public T[] GetModifiers()
		{
			return mods.ToArray();
		}

		public void AddModifier(T mod)
		{
			mods.Add(mod);
			mod.ValueChanged += OnModChanged;
			CalcValue();
		}

		public void RemoveModifier(T mod)
		{
			if (mods.Remove(mod))
			{
				mod.ValueChanged -= OnModChanged;
				CalcValue();
			}
		}

		private void OnModChanged(IValueModifier mod)
		{
			CalcValue();
		}

		private void CalcValue()
		{
			Value = BaseValue;
			foreach (T mod in mods)
			{
				Value = mod.Modify(Value);
			}
			ValueChanged(this);
		}
	}
}