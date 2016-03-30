namespace DynamicProxyTest.Model
{
	using System;

	using DynamicProxyTest.Model.Sitecore;

	public class ItemWrapper : IItemWrapper
	{
		private readonly Item item;

		public ItemWrapper(Item item)
		{
			this.item = item;
		}

		public string ItemName
		{
			get { return this.item.ItemName; }
			set { this.item.ItemName = value; }
		}

		public Guid ID
		{
			get { return this.item.ItemId; }
			set { this.item.ItemId = value; }
		}
	}

	public class Content : ItemWrapper, IContent
	{
		public Content(Item item) : base(item)
		{
		}

		public string Title { get; set; }
		public string Body { get; set; }
	}
}