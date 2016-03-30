namespace DynamicProxyTest.Model
{
	using System;

	using Castle.DynamicProxy;

	using DynamicProxyTest.Model.Sitecore;
	using DynamicProxyTest.Proxy;

	public class SpawnProvider
	{
		public static ProxyGenerator Generator { get; } = new ProxyGenerator();

		public static T SpawnFromItem<T>(Item item) where T : IItemWrapper
		{
			object wrapper = null;
			try
			{
				wrapper = FromItem<T>(item);
			}
			catch { }
			return (T)((wrapper is T) ? wrapper : null);
		}

		public static IItemWrapper FromItem(Item item)
		{
			return FromItem<IItemWrapper>(item);
		}

		public static IItemWrapper FromItem<T>(Item item) where T : IItemWrapper
		{
			return FromItem<T>(item, typeof(T));
		}

		public static IItemWrapper FromItem<T>(Item item, Type template) where T : IItemWrapper
		{
			var itemWrapper = new ItemWrapper(item);

			var proxy = DelegateWrapper.WrapAs<T>(itemWrapper);
			return proxy;
		}
	}
}