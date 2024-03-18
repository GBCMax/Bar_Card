using Bar_Card.Data;

namespace Bar_Card
{
	public partial class App : Application
	{
		private const string DbName = "Drinks.db3";
		private static string _dbPath => Path.Combine(FileSystem.AppDataDirectory, DbName);

		private static DataBaseService database;
		public static DataBaseService Database
		{
			get
			{
				if (database == null)
				{
					database = new DataBaseService(_dbPath);
				}
				return database;
			}
		}

		public App()
		{
			InitializeComponent();

			MainPage = new AppShell();
		}
	}
}
