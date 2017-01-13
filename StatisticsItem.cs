
using System;

namespace Statistik
{
	public class StatisticsItem
	{
		string itemName;
		int itemCount;

		public StatisticsItem(string name)
		{
			itemName = name;
			itemCount = 0;
		}

		public string ItemName
		{
			get
			{
				return itemName;
			}
		}

		public int ItemCount
		{
			get
			{
				return itemCount;
			}
			set
			{
				itemCount = value;
			}
		}

		public void AddItemCount()
		{
			itemCount++;
		}
	}
}
