namespace SingletonPattern.Services
{
	public interface ISingletonService
	{
		T SingletonInstance<T>(T t) where T : class;
	}
}
