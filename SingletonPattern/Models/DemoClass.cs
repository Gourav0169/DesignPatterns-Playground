namespace SingletonPattern.Models
{
	public class DemoClass
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public string? Description { get; set; }

		public static DemoClass CreateDemoClassInstance()
		{
			DemoClass instance = new DemoClass
			{
				Id = 1,
				Name = "test",
				Description = "This is a test instance of the class",
			};

			return instance;
		}

	}
}
