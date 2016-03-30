namespace DynamicProxyTest.Model
{
	public interface IContent : IItemWrapper
	{
		string Title { get; set; }
		string Body { get; set; }
	}
}
