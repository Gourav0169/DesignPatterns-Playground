using System.Collections.Concurrent;

namespace SingletonPattern.Services
{
	public class SingletonService : ISingletonService
	{
		private static ConcurrentDictionary<Type, Lazy<object>> _instance = new();

		public T SingletonInstance<T>(T t) where T : class
		{
			var type =  typeof(T);
			var lazyInstance = _instance.GetOrAdd(type, _ => new Lazy<object>(() => t, LazyThreadSafetyMode.ExecutionAndPublication));

			return (T)lazyInstance.Value;
		}
	}
}
