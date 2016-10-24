namespace Saving
{
	public interface SaveSystem
	{
		string FileName
		{
			get;
			set;
		}

		void Store<T>(string key, T value) where T : Storable;

		T Load<T>(string key) where T : Storable;

		void LoadPersistentData();

		void Persist();
	}
}