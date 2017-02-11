using System;

namespace Statistics
{
	public class StatisticsItem
	{
		string itemName;
		int itemCount;

		public StatisticsItem(string name, int count)
		{
			itemName = name;
			itemCount = count;
		}

		public string ItemName {
			get {
				return itemName;
			}
		}

		public int ItemCount {
			get {
				return itemCount;
			}
		}

		public void AddItemCount()
		{
			itemCount = itemCount++;
		}
		
		public void SubtractItemCount()
		{
			itemCount = itemCount--;
		}
	}
}
