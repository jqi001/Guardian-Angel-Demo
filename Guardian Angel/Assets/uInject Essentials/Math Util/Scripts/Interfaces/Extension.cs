namespace MathUtil
{
	public static class Extension
	{
		public static NamedValueModifier GetModifier(this ModifiableValue<NamedValueModifier> value, string name)
		{
			foreach (NamedValueModifier mod in value.GetModifiers())
			{
				if (mod.Name.Equals(name))
				{
					return mod;
				}
			}
			return null;
		}
	}
}