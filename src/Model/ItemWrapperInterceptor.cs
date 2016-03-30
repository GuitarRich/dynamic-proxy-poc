namespace DynamicProxyTest.Model
{
	using System;
	using System.Reflection;

	using Castle.DynamicProxy;
	public class ItemWrapperInterceptor : IInterceptor
	{
		protected readonly IItemWrapper ItemWrapper;

		private Func<string> getProperty = () => "This is the delegate method";

		public ItemWrapperInterceptor(IItemWrapper itemWrapper)
		{
			this.ItemWrapper = itemWrapper;
		}

		public void Intercept(IInvocation invocation)
		{
			if (invocation.Method.DeclaringType.FullName.Contains("IItemWrapper"))
			{
				// Invoke the method from the internal ItemWrapper
				var result = this.ItemWrapper.GetType().InvokeMember(invocation.Method.Name, BindingFlags.InvokeMethod, null, this.ItemWrapper, invocation.Arguments);
				invocation.ReturnValue = result;

				return;
			}

			if (invocation.Method.Name.StartsWith("get_"))
			{
				// do the get
				var result = this.getProperty.DynamicInvoke(invocation.Arguments);
				invocation.ReturnValue = result;

				return;
			}

			invocation.ReturnValue = "NOT FOUND";
		}
	}
}
