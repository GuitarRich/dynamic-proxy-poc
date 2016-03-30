namespace DynamicProxyTest
{
	using System;

	using DynamicProxyTest.Model;
	using DynamicProxyTest.Model.Sitecore;

	internal class Program
	{
		static void Main(string[] args)
		{
			var contentItem = new Item
			{
				ItemName = "content-page",
				ItemId = Guid.NewGuid()
			};

			var content = SpawnProvider.SpawnFromItem<IContent>(contentItem);
            if (content == null)
			{
				throw new NullReferenceException();
			}

			content.Title = "This is the title";
			content.Body = "body content";

			Console.WriteLine($"The ItemId is [{content.ID}]");
			Console.WriteLine($"The Item Name is [{content.ItemName}]");
			Console.WriteLine($"The title is [{content.Title}]");
			Console.ReadLine();
		}
	}
}
