namespace MathUtil
{
	public class Adder : ValueModifier
	{
		public Adder(double value) : base(value)
		{
		}

		public override double Modify(double value)
		{
			return value + this.Value;
		}
	}
}