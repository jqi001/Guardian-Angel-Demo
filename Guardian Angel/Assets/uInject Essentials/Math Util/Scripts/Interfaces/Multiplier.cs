namespace MathUtil
{
	public class Multiplier : ValueModifier
	{
		public Multiplier(double value) : base(value)
		{
		}

		public override double Modify(double value)
		{
			return value * this.Value;
		}
	}
}