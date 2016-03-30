namespace DynamicProxyTest.Proxy
{
	using System;

	using Castle.DynamicProxy;

	using DynamicProxyTest.Logging;
	using DynamicProxyTest.Model;

	public class DelegateWrapper
	{
		public static TInterface WrapAs<TInterface>(Delegate d1, Delegate d2)
		{
			var generator = new ProxyGenerator();
			var options = new ProxyGenerationOptions { Selector = new DelegateSelector() };
			var proxy = generator.CreateInterfaceProxyWithoutTarget(
				typeof(TInterface),
				new Type[0],
				options,
				new MethodInterceptor(d1),
				new MethodInterceptor(d2));

			return (TInterface)proxy;
		}

		public static T WrapAs<T>(Delegate impl) where T : class
		{
			var generator = new ProxyGenerator();
			var proxy = generator.CreateInterfaceProxyWithoutTarget(typeof(T), new MethodInterceptor(impl));
			return (T)proxy;
		}

		public static T WrapAs<T>(IItemWrapper itemWrapper)
		{
			var generator = new ProxyGenerator();
			var proxy = generator.CreateInterfaceProxyWithoutTarget(typeof(T), new CallLoggingInterceptor(), new ItemWrapperInterceptor(itemWrapper));
			return (T)proxy;
		}
	}
}
