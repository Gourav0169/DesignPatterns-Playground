using System.Collections.Concurrent;
using System.Dynamic;
using SingletonPattern.Models;

namespace SingletonPattern.Services
{
	public class SingletonService : ISingletonService
	{
		private static readonly ConcurrentDictionary<Type, object> _basicInstances = new();
		private static readonly ConcurrentDictionary<Type, Lazy<object>> _lazyInstances = new();
		private static readonly ConcurrentDictionary<Type, object> _threadSafeInstances = new();
		private static readonly ConcurrentDictionary<Type, Lazy<object>> _lazyThreadSafeInstances = new();
		private static readonly object _lock = new();

		public T BasicSingletonInstance<T>(Func<T> factory) where T : class
		{
			var type = typeof(T);
			if (!_basicInstances.ContainsKey(type))
				_basicInstances[type] = factory();

			return (T)_basicInstances[type];
		}

		public T LazySingletonInstance<T>(Func<T> factory) where T : class
		{
			var type = typeof(T);
			var lazyInstance = _lazyInstances.GetOrAdd(type, _ => new Lazy<object>(factory));
			return (T)lazyInstance.Value;
		}

		public T ThreadSafeSingletonInstance<T>(Func<T> factory) where T : class
		{
			var type = typeof(T);
			if (!_threadSafeInstances.ContainsKey(type))
			{
				lock (_lock)
				{
					if (!_threadSafeInstances.ContainsKey(type))
						_threadSafeInstances[type] = factory();
				}
			}

			return (T)_threadSafeInstances[type];
		}

		public T LazyThreadSafeSingletonInstance<T>(Func<T> factory) where T : class
		{
			var type = typeof(T);
			var lazyInstance = _lazyThreadSafeInstances.GetOrAdd(type,
				_ => new Lazy<object>(factory, LazyThreadSafetyMode.ExecutionAndPublication));
			return (T)lazyInstance.Value;
		}
	}
}
