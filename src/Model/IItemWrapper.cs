namespace DynamicProxyTest.Model
{
	using System;

	public interface IItemWrapper
	{
		string ItemName { get; set; }
		Guid ID { get; set; }
	}
}
