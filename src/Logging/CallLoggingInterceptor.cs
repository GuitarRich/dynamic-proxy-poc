namespace DynamicProxyTest.Logging
{
	using System;
	using Castle.DynamicProxy;

	[Serializable]
	public class CallLoggingInterceptor : IInterceptor
	{
		private int indention;

		public void Intercept(IInvocation invocation)
		{
			try
			{
				this.indention++;
				Console.WriteLine("{0}Intercepting: {1}", new string('\t', this.indention), invocation.Method.Name);
				invocation.Proceed();
			}
			catch (Exception ex)
			{
				Console.WriteLine("Exception in method {0}{1}{2}", invocation.Method.Name, Environment.NewLine, ex.Message);
				throw;
			}
			finally
			{
				this.indention--;
			}
		}
	}
}
