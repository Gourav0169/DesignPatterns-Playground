using SingletonPattern.Models;

namespace SingletonPattern.Services
{
	public interface ISingletonService
	{
		T BasicSingletonInstance<T>(Func<T> factory) where T : class;
		T LazySingletonInstance<T>(Func<T> factory) where T : class;
		T ThreadSafeSingletonInstance<T>(Func<T> factory) where T : class;
		T LazyThreadSafeSingletonInstance<T>(Func<T> factory) where T : class;
	}
}
